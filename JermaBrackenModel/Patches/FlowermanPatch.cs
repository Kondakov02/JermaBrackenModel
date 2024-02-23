using HarmonyLib;
using JermaBrackenModel.Scripts;
using UnityEngine;

namespace JermaBrackenModel.Patches
{
    [HarmonyPatch(typeof(FlowermanAI))]
    internal class FlowermanPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(FlowermanAI.Start))]
        public static void injectController(FlowermanAI __instance)
        {
            ((Component)__instance).gameObject.AddComponent<JermaController>();
        }
    }
}
