using BIGSHOTDISCO;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace LethalCompanyTemplate.Patches
{
    [HarmonyPatch(typeof(CozyLights))]
    internal class CozyLightsPatch
    {
        [HarmonyPatch("SetAudio")]
        [HarmonyPostfix]
        static void patchFunction(CozyLights __instance)
        {
            __instance.turnOnAudio.clip = Mod.sounds[0];
        }
    }
}
