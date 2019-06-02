var gulp = require("gulp");
var msbuild = require("gulp-msbuild");
var debug = require("gulp-debug");
var foreach = require("gulp-foreach");
var rename = require("gulp-rename");
var watch = require("gulp-watch");
var merge = require("merge-stream");
var newer = require("gulp-newer");
var util = require("gulp-util");
var runSequence = require("run-sequence");
var path = require("path");
var config = require("./gulp-config.js")();
var nugetRestore = require('gulp-nuget-restore');
var fs = require('fs');
var unicorn = require("./scripts/unicorn.js");
var habitat = require("./scripts/habitat.js");
var yargs = require("yargs").argv;
var exec = require("child_process").exec;
var request = require('request');   

module.exports.config = config;

/*****************************
  Initial setup
*****************************/

gulp.task("Create-Local-Properties", function (callback) {
    exec("Powershell.exe -File scripts\\nant\\LocalProperties.ps1", function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        callback(err);
    });
});

gulp.task("Nant", function (callback) {
    exec("nant init -D:env=local", function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        callback(err);
    });
});

gulp.task("Full-Setup", function (callback) {
  config.runCleanBuilds = true;
  return runSequence(
    "Nant",
    "Nuget-Restore",
    "Publish-All-Projects",
    "Sync-Unicorn",
	callback);
});

gulp.task("Sync-Unicorn", function (callback) {
  var options = {};
  options.siteHostName = habitat.getSiteUrl();
  options.authenticationConfigFile = config.websiteRoot + "/App_config/Include/Unicorn/Unicorn.UI.config";

  unicorn(function() { return callback() }, options);
});

/*****************************
  Build
*****************************/

gulp.task("Build-Solution", function () {
    var targets = ["Build"];
    if (config.runCleanBuilds) {
        targets = ["Clean", "Build"];
    }

    var solution = "./" + config.solutionName + ".sln";
    return gulp.src(solution)
        .pipe(msbuild({
            targets: targets,
            configuration: config.buildConfiguration,
            logCommand: false,
            verbosity: "minimal",
            stdout: true,
            errorOnFail: true,
            maxcpucount: 0,
            toolsVersion: config.buildToolsVersion,
            properties: {
                Platform: config.buildPlatform
            }
        }));
});

/*****************************
  Publish
*****************************/

var publishStream = function (stream, dest) {
  var targets = ["Build"];

  return stream
    .pipe(debug({ title: "Building project:" }))
    .pipe(msbuild({
      targets: targets,
      configuration: config.buildConfiguration,
      logCommand: false,
      verbosity: "minimal",
      stdout: true,
      errorOnFail: true,
      maxcpucount: 0,
      toolsVersion: config.buildToolsVersion,
      properties: {
        Platform: config.publishPlatform,
        DeployOnBuild: "true",
        DeployDefaultTarget: "WebPublish",
        WebPublishMethod: "FileSystem",
        DeleteExistingFiles: "false",
        publishUrl: dest,
        _FindDependencies: "false"
      }
    }));
}

var publishProject = function (location, dest) {
    dest = dest || config.websiteRoot;

    console.log("publish to " + dest + " folder");
    return gulp.src(["./src/" + location + "/code/*.csproj"])
        .pipe(foreach(function (stream, file) {
            return publishStream(stream, dest);
        }));
}

var publishProjects = function (location, dest) {
  dest = dest || config.websiteRoot;

  console.log("publish to " + dest + " folder");
  return gulp.src([location + "/**/code/*.csproj"])
    .pipe(foreach(function (stream, file) {
      return publishStream(stream, dest);
    }));
};

gulp.task("Publish-Foundation", function () {
  return publishProjects("./src/Foundation");
});

gulp.task("Publish-Feature", function () {
  return publishProjects("./src/Feature");
});

gulp.task("Publish-Project", function () {
    return publishProjects("./src/Project");
});

gulp.task("Publish-All-Views", function () {
  var root = "./src";
  var roots = [root + "/**/Views", "!" + root + "/**/obj/**/Views"];
  var files = "/**/*.cshtml";
  var destination = config.websiteRoot + "\\Views";
  return gulp.src(roots, { base: root }).pipe(
    foreach(function (stream, file) {
      console.log("Publishing from " + file.path);
      gulp.src(file.path + files, { base: file.path })
        .pipe(newer(destination))
        .pipe(debug({ title: "Copying " }))
        .pipe(gulp.dest(destination));
      return stream;
    })
  );
});

gulp.task("Publish-All-Projects", function (callback) {
    return runSequence(
        "Nant",
        "Build-Solution",
        "Publish-Foundation",
        "Publish-Feature",
        "Publish-Project", callback);
});

gulp.task("Publish-All-Configs", function () {
  var root = "./src";
  var roots = [root + "/**/App_Config", "!" + root + "/**/obj/**/App_Config"];
  var files = "/**/*.config";
  var destination = config.websiteRoot + "\\App_Config";
  return gulp.src(roots, { base: root }).pipe(
    foreach(function (stream, file) {
      console.log("Publishing from " + file.path);
      gulp.src(file.path + files, { base: file.path })
        .pipe(newer(destination))
        .pipe(debug({ title: "Copying " }))
        .pipe(gulp.dest(destination));
      return stream;
    })
  );
});

gulp.task("Publish-MSSDK", function () {
    return publishProject("Foundation\\MSSDK");
});

gulp.task("Publish-SCSDK", function () {
    return publishProject("Foundation\\SCSDK");
});

gulp.task("Publish-OleChat", function (callback) {
    publishProject("Feature\\OleChat");
    return runSequence(
        "Publish-SCSDK",
        "Sync-Unicorn", callback);
});

gulp.task("Publish-LaunchDemo", function (callback) {
    publishProject("Project\\LaunchDemo");
    return runSequence(
        "Publish-SCSDK",
        "Sync-Unicorn", callback);
});

gulp.task("Publish-IntelligentMedia", function (callback) {
    publishProject("Feature\\IntelligentMedia");
    runSequence(
        "Publish-SCSDK",
        "Sync-Unicorn", callback);
});

/*****************************
  Deploy
*****************************/

gulp.task("Deploy-All-Projects", function (callback) {
    config.runCleanBuilds = true;
    return runSequence(
        "Nuget-Restore",
        "Publish-All-Projects",
        callback);
});

/*****************************
  Nuget 
*****************************/

gulp.task("Nuget-Restore", function (callback) {
    var solution = "./" + config.solutionName + ".sln";
    return gulp.src(solution).pipe(nugetRestore());
});

gulp.task('Nuget-Download', function (done) {
    if (fs.existsSync('nuget.exe'))
        return done();
    
    request.get('http://nuget.org/nuget.exe')
        .pipe(fs.createWriteStream('nuget.exe'))
        .on('close', done);
});

gulp.task("Nuget-Create-Folder", function(done) {
    try {
        fs.mkdir('./nuget');
    } catch (ex) {
        return done();
    }
});

gulp.task("Nuget-Pack-Core", function (callback) {
    gulp.start('Nuget-Create-Folder');
    gulp.start('Nuget-Download');
    
    exec("nuget pack ./src/Foundation/SCSDK/code/SitecoreCognitiveServices.Core.nuspec -OutputDirectory ./nuget && " + 
        "nuget pack ./src/Foundation/SCSDK/code/SitecoreCognitiveServices.Core.BinariesOnly.nuspec -OutputDirectory ./nuget", function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        callback(err);
    });
});

gulp.task("Nuget-Pack-Ole", function (callback) {
    gulp.start('Nuget-Create-Folder');
    gulp.start('Nuget-Download');

    exec("nuget pack ./src/Feature/OleChat/code/SitecoreCognitiveServices.OleChat.nuspec -OutputDirectory ./nuget && " + 
        "nuget pack ./src/Feature/OleChat/code/SitecoreCognitiveServices.OleChat.BinariesOnly.nuspec -OutputDirectory ./nuget", function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        callback(err);
    });
});
