using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGameFile : MonoBehaviour
{
	public string SaveGameName;

	public SaveGameFile(string saveName)
	{
		SaveGameName = saveName;
	}
}
