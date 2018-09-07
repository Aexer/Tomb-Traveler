using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
	private static string _currentSaveProfile;

	public static string CurrentSaveProfile
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
}