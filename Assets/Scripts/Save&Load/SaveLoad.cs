using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
	public static int numSaves = GetNumSaves();
	
	public static void SaveGame(string filename, SaveGameFile data)
	{
		CheckSaveFolder();
		string destination = Application.persistentDataPath + "/SaveGames/" + filename + ".SaveGame";
		FileStream file;

		if (File.Exists(destination)) file = File.OpenWrite(destination);
		else file = File.Create(destination);
		
		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(file, data);
		file.Close();
	}

	public static SaveGameFile LoadGame(string filename)
	{
		CheckSaveFolder();
		string destination = Application.persistentDataPath + "/SaveGames/" + filename + ".SaveGame";
		FileStream file;

		if (File.Exists(destination))
		{
			file = File.OpenRead(destination);
		}
		else
		{
			return null;
		}

		BinaryFormatter bf = new BinaryFormatter();
		SaveGameFile data = (SaveGameFile)bf.Deserialize(file);
		file.Close();
		
		return data;
	}

	public static SaveGameFile LoadFirstSave()
	{
		CheckSaveFolder();
		string destination = Application.persistentDataPath + "/SaveGames/";
		BinaryFormatter bf = new BinaryFormatter();


		foreach (string path in System.IO.Directory.GetFiles(destination))
		{
			if (path.EndsWith(".SaveGame"))
			{
				FileStream file;
				file = File.OpenRead(path);
				SaveGameFile save = (SaveGameFile)bf.Deserialize(file);
				file.Close();
				return save;
			}
		}
		return null;//Create New Empty Save
	}

	public static List<SaveGameFile> LoadAllSaves()
	{
		CheckSaveFolder();
		List<SaveGameFile> Saves = new List<SaveGameFile>();
		string destination = Application.persistentDataPath + "/SaveGames/";
		BinaryFormatter bf = new BinaryFormatter();


		foreach (string path in System.IO.Directory.GetFiles(destination))
		{
			if (path.EndsWith(".SaveGame"))
			{
				FileStream file;
				file = File.OpenRead(path);
				Saves.Add((SaveGameFile)bf.Deserialize(file));
				file.Close();
			}
		}
		return Saves;
	}

	public static GlobalSaveFile LoadGlobalSaveData()
	{
		string destination = Application.persistentDataPath + "/GlobalSaveData.GlobalSaveFile";
		FileStream file;

		if (File.Exists(destination))
		{
			file = File.OpenRead(destination);
		}
		else
		{
			return new GlobalSaveFile("");
		}

		BinaryFormatter bf = new BinaryFormatter();
		GlobalSaveFile data = (GlobalSaveFile)bf.Deserialize(file);
		file.Close();

		return data;
	}

	public static bool DoSavesExist()
	{
		CheckSaveFolder();
		string destination = Application.persistentDataPath + "/SaveGames/";
		foreach (string file in System.IO.Directory.GetFiles(destination))
		{
			if (file.EndsWith(".SaveGame")) return true;
		}
		return false;
	}

	public static int GetNumSaves()
	{
		CheckSaveFolder();
		string destination = Application.persistentDataPath + "/SaveGames/";
		int c = 0;
		foreach (string file in System.IO.Directory.GetFiles(destination))
		{
			if (file.EndsWith(".SaveGame"))c++;
		}
		return c;
	}

	private static void CheckSaveFolder()
	{
		string destination = Application.persistentDataPath + "/SaveGames/";
		if (!File.Exists(destination))
		{
			System.IO.Directory.CreateDirectory(destination);
		}
	}
}
