using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalSaveFile : MonoBehaviour
{
	public string LastSavedGameName;

	public GlobalSaveFile(string lastSavedName)
	{
		LastSavedGameName = lastSavedName;
	}
}
