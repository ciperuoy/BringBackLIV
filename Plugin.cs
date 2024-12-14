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

        private void disable()
        {
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (obj.activeInHierarchy && MatchesTargetName(obj.name))
                {
                    obj.SetActive(false);
                }
            }
        }

        private bool MatchesTargetName(string name)
        {
            name = name.ToLower();
            foreach (string targetName in targetNames)
            {
                if (name == targetName.ToLower()) 
                {
                    return true;
                }
            }
                return false;
        	}

        	void Start()
		{
			GorillaTagger.OnPlayerSpawned(Initialized);
		}

		void Initialized()
		{
           	 disable();
        	}
	}
}
