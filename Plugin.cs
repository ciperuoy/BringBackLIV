using System;
using BepInEx;
using sigmamodtemplate;
using UnityEngine;

namespace sigmamodtemplate
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
        private readonly string[] targetNames =
{
            "LCKWallCameraSpawner"
        };

        private void DisableTargetObjects()
        {
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (obj.activeInHierarchy && MatchesTargetName(obj.name))
                {
                    obj.SetActive(false);
                    Debug.Log($"Disabled object: {obj.name}");
                }
            }
        }

        private bool MatchesTargetName(string name)
        {
            name = name.ToLower();
            foreach (string targetName in targetNames)
            {
                if (name == targetName.ToLower()) // Match exact names
                {
                    return true;
                }
            }
            return false;
        }

        void Start()
		{
            HarmonyPatches.ApplyHarmonyPatches();
			GorillaTagger.OnPlayerSpawned(Initialized);
		}

		void Initialized()
		{
            DisableTargetObjects();
        }
	}
}
