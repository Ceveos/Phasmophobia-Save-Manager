using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Phasmophobia_Save_Manager.FileManager
{
    public static class SaveFileComponents
    {
        public static Dictionary<string, SectionInfo> SectionsToCheck = new Dictionary<string, SectionInfo>()
            {
                {
                    "StringData",
                    new SectionInfo()
                    {
                        SectionType = JTokenType.String,
                        KnownFields = new List<string>() { "GhostType" }
                    }
                },
                {
                    "IntData",
                    new SectionInfo()
                    {
                        SectionType = JTokenType.Integer,
                        KnownFields = new List<string>() {
                            "myTotalExp",
                            "PlayersMoney",
                            "EMFReaderInventory",
                            "FlashlightInventory",
                            "CameraInventory",
                            "LighterInventory",
                            "CandleInventory",
                            "UVFlashlightInventory",
                            "CrucifixInventory",
                            "DSLRCameraInventory",
                            "EVPRecorderInventory",
                            "SaltInventory",
                            "SageInventory",
                            "TripodInventory",
                            "StrongFlashlightInventory",
                            "MotionSensorInventory",
                            "SoundSensorInventory",
                            "SanityPillsInventory",
                            "ThermometerInventory",
                            "GhostWritingBookInventory",
                            "IRLightSensorInventory",
                            "ParabolicMicrophoneInventory",
                            "GlowstickInventory",
                            "HeadMountedCameraInventory",
                            "PlayerDied",
                            "MissionStatus",
                            "LevelDifficulty",
                            "completedTraining",
                            "setupPhase",
                            "StayInServerRoom",
                            "totalExp",
                            "isTutorial",
                        }
                    }
                },
                {
                    "FloatData",
                    new SectionInfo()
                    {
                        SectionType = JTokenType.Float,
                        KnownFields = new List<string>() { }
                    }
                },
                {
                    "BoolData",
                    new SectionInfo()
                    {
                        SectionType = JTokenType.Boolean,
                        KnownFields = new List<string>() { }
                    }
                },
            };
    }

    public struct SectionInfo
    {
        public JTokenType SectionType;
        public List<string> KnownFields;
    }
}
