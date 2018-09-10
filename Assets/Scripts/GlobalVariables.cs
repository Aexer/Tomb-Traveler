using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
	private static SaveGameFile _currentSaveProfile;
	private static GlobalSaveFile _globalSaveData = SaveLoad.LoadGlobalSaveData();

	public static SaveGameFile CurrentSaveProfile
	{
		get
		{
			return _currentSaveProfile;
		}
		set
		{
			_currentSaveProfile = value;
		}
	}

	public static GlobalSaveFile GlobalSaveData
	{
		get
		{
			return _globalSaveData;
		}
		set
		{
			_globalSaveData = value;
		}
	}
}