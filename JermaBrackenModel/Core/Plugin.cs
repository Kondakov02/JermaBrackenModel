using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using JermaBrackenModel.Patches;
using System.IO;
using UnityEngine;

namespace JermaBrackenModel.Core
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class ModBase : BaseUnityPlugin
    {
        private const string modGUID = "thekagamiest.JermaBrackenModel";

        private const string modName = "Jerma Bracken Model";

        private const string modVersion = "1.0.0";

        private const string bundleName = "jerma";

        private static ModBase _instance;

        internal static ModBase Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                if ((Object)(object)_instance == (Object)null)
                {
                    _instance = value;
                }
                else
                {
                    Object.Destroy((Object)(object)value);
                }
            }
        }

        private readonly Harmony harmony = new Harmony(modGUID);

        public static ManualLogSource logger;

        void Awake() 
        { 
            Instance = this;

            logger = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            logger.LogInfo("Plugin initialized");

            string assetBundlePath = Path.Combine(Path.GetDirectoryName(((BaseUnityPlugin)this).Info.Location), bundleName);

            logger.LogInfo("Loading the asset bundle from " + assetBundlePath);

            Assets.LoadBundle(assetBundlePath);

            logger.LogInfo("Patching game files");

            harmony.PatchAll(typeof(ModBase));
            harmony.PatchAll(typeof(FlowermanPatch));

            logger.LogInfo("All done");
        }
    }
}
