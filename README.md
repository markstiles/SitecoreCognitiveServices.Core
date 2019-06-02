# SitecoreCognitiveServices
SDK integrating Microsoft's Cognitive Services into Sitecore

## Getting the demo site up and running
This is largely copied from the original [source](https://www.markstiles.net/blog/2017/2/22/sitecore-cognitive-services/) and updated to make the installation a bit easier.

__Environment Prep__
- Get a set of API Keys from Microsoft
- SIM Install a version of Sitecore 8.2
- Download the source code from GitHub

__Configuration files__

- Open the root source code folder and run the `setup.bat` script (make sure that the PowerShell execution policy is at least set to [RemoteSigned](https://ss64.com/ps/set-executionpolicy.html)).
- Open the solution in Visual Studio and in the solution explorer open /Configuration/Properties/local.properties and fill out the project.* properties and any cognitive.* properties you have keys for
- Open the Task Runner Explorer and run the Nant command to push all your local properties out to the templated files in the project
- Build the solution (to ensure all the Nuget packages get downloaded because this doesn't always work right away)
- Publish the MSSDK, SCSDK, OleChat and IntelligentMedia projects

__Unicorn sync__
- Browse to `http://<domain>/unicorn.aspx` and sync the configurations
- Additionally you may want to browse to these files and force refresh them (browsers cache them)
  - `http://<domain>/sitecore/shell/Themes/Standard/Default/Content%20Manager.css`
  - `http://<domain>/sitecore/shell/Controls/Rich%20Text%20Editor/RichText%20Commands.js`

__Sitecore__
- Log into Sitecore, go to the Control Panel
- Browse to /sitecore/system/modules/Sitecore Cognitive Services/ and for both 'Ole Chat' and 'Image Search' click on the node and enter the values if you still need to and submit the setup form
- You can now either open Ole from the LaunchPad or Content Editor Ribbon under the 'Cognitive' tab
- You can also now click on any folder in the media library to analyze the images under it, then open the search through the rich text editor (full profile) or by using the newly installed 'Cognitive Image Field' buttons

## Troubleshooting
<dl>
  <dt>How do I get API keys?</dt>
  <dd><p>Check out some of the answers on this StackOverflow question: https://stackoverflow.com/questions/40757076/unable-to-find-subscription-key-for-microsoft-cognitive-services</p>
  <p>
In general, you need to provision the service in Azure Portal and then go to the Keys section and copy the primary key value for that particular service. This needs to be done for each service you want to use.</p></dd>

  <dt>My API key is specified, but I am getting a "access denied due to invalid subscription key" error. What gives?</dt>
  <dd><p>The keys appear to be specific to region. You need to configure the endpoint for your API to match to the endpoint in your Azure portal. The config file where you specify your key will have an endpoint setting where you can place the value.</p>
  <p>See this Stackoverflow question for an example with the Face API: https://stackoverflow.com/questions/43918434/face-api-access-denied-due-to-invalid-subscription-key</p></dd>
  
  <dt>Visual Studio Publish fails with access error for target folder</dt>
  <dd>If you have installed Sitecore in a restricted area, such as the standard inetpub\wwwroot folder, you need elevated access to publish to this area of the file system. Launch Visual Studio in Administrator mode to allow you to publish to these folders.</dd>
  
  <dt>After publishing Sitecore shows error 'Access to the path denied' when executing Rainbow.Storage.SerializationFileSystemDataStore.InitializeRootPath</dt>
  <dd><p>By default, the PowerShell setup script will initialize your serialization folder (`serializationRootPath` setting in `App_Config\Include\SitecoreCognitiveServices\UnicornSerializationRoot.config`) to the location where your CognitiveServices project source code is located. Your IIS worker process likely does not have access to your source control folder if you receive this message. </p>
  <p>To correct the issue, navigate in Windows Explorer to your serialization folder (e.g `{sourcepath}\SitecoreCognitiveServices\serialization`). Right-click on the folder and open the Security dialog. Grant modify access to the local IIS_IUSRS group (or the equivalent on your OS version/application pool configuration).
  </p></dd>
</dl>
