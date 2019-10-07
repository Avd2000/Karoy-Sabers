using UnityEngine;
using UnityEditor;

[InitializeOnLoadAttribute]
public static class EscapeXRSettingOnPlay
{
	static EscapeXRSettingOnPlay()
	{
		EditorApplication.playModeStateChanged += EscapeXRSetting;
	}

	private static void EscapeXRSetting(PlayModeStateChange state)
	{
		if (state == PlayModeStateChange.EnteredEditMode)
		{
			PlayerSettings.virtualRealitySupported = true;
		}
		else if (state == PlayModeStateChange.ExitingEditMode)
		{
			PlayerSettings.virtualRealitySupported = false;
		}
	}
}