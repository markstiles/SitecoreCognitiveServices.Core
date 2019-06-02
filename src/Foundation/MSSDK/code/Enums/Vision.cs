using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Enums
{
    public enum ContentModeratorTag
    {
        None = 0,
        Nudity = 101,
        SexualContent = 102,
        Alcohol = 201,
        Tobacco = 202,
        Drugs = 203,
        ChildExploitation = 301,
        Violence = 401,
        Weapons = 402,
        Gore = 403,
        Profanity = 501,
        Vulgarity = 502,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentModeratorReviewStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Failed")]
        Failed,
        [EnumMember(Value = "Complete")]
        Complete
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentModeratorReviewType
    {
        [EnumMember(Value = "Text")]
        Text = 0,
        [EnumMember(Value = "Image")]
        Image = 1,
        [EnumMember(Value = "Video")]
        Video = 2
    }

    public enum ContentModeratorVideoModeOptions { Speed, Balance, Quality }

    public enum VideoOutputStyleOptions { Aggregate, PerFrame }

    public enum SensitivityOptions { low, medium, high }

    public enum VisualFeature { ImageType, Color, Faces, Adult, Categories, Tags, Description }

    public enum VideoOperationStatus {
        NotStarted,
        Uploading,
        Running,
        Failed,
        Succeeded,
    }

    public enum Glasses {
        NoGlasses,
        Sunglasses,
        ReadingGlasses,
        SwimmingGoggles,
    }

    public enum FindSimilarMatchMode {
        matchPerson,
        matchFace,
    }

    public enum FaceAttributeType {
        Age,
        Gender,
        FacialHair,
        Smile,
        HeadPose,
        Glasses,
        Emotion
    }

    public enum ImageCategory
    {
        abstract_,
        abstract_net,
        abstract_nonphoto,
        abstract_rect,
        abstract_shape,
        abstract_texture,
        animal_,
        animal_bird,
        animal_cat,
        animal_dog,
        animal_horse,
        animal_panda,
        building_,
        building_arch,
        building_brickwall,
        building_church,
        building_corner,
        building_doorwindows,
        building_pillar,
        building_stair,
        building_street,
        dark_,
        drink_,
        drink_can,
        dark_fire,
        dark_fireworks,
        sky_object,
        food_,
        food_bread,
        food_fastfood,
        food_grilled,
        food_pizza,
        indoor_,
        indoor_churchwindow,
        indoor_court,
        indoor_doorwindows,
        indoor_marketstore,
        indoor_room,
        indoor_venue,
        dark_light,
        others_,
        outdoor_,
        outdoor_city,
        outdoor_field,
        outdoor_grass,
        outdoor_house,
        outdoor_mountain,
        outdoor_oceanbeach,
        outdoor_playground,
        outdoor_railway,
        outdoor_road,
        outdoor_sportsfield,
        outdoor_stonerock,
        outdoor_street,
        outdoor_water,
        outdoor_waterside,
        people_,
        people_baby,
        people_crowd,
        people_group,
        people_hand,
        people_many,
        people_portrait,
        people_show,
        people_tattoo,
        people_young,
        plant_,
        plant_branch,
        plant_flower,
        plant_leaves,
        plant_tree,
        object_screen,
        object_sculpture,
        sky_cloud,
        sky_sun,
        people_swimming,
        outdoor_pool,
        text_,
        text_mag,
        text_map,
        text_menu,
        text_sign,
        trans_bicycle,
        trans_bus,
        trans_car,
        trans_trainstation
    }
}