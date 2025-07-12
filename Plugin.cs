using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LethalCompanyTemplate.Patches;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BIGSHOTDISCO
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Mod : BaseUnityPlugin
    {
        private const string modGUID = "Duttbust.BIGSHOTDISCO";
        private const string modName = "BIGSHOTDISCO";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        internal static Mod Instance;

        internal ManualLogSource mls;

        internal static List<AudioClip> sounds;
        internal static AssetBundle bundle;

        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            if ( Instance == null )
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            harmony.PatchAll(typeof(CozyLightsPatch));

            sounds = new List<AudioClip>();
            string FolderLocation = Instance.Info.Location;
            FolderLocation = FolderLocation.TrimEnd("BIGSHOTDISCO.dll".ToCharArray());
            bundle = AssetBundle.LoadFromFile(FolderLocation + "music");
            if( bundle != null)
            {
                mls.LogInfo("Loaded AssetBundle!");
                sounds = bundle.LoadAllAssets<AudioClip>().ToList();
            }
            else
            {
                mls.LogError("Failed to load AssetBundle");
            }
            
        }
    }
}