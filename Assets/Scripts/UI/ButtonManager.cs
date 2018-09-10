using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
	private void Start()
	{
		GameObject LoadSaveButton = GameObject.Find("Load Save Button");
		if (LoadSaveButton != null)
		{
			if(SaveLoad.numSaves < 2)
			{
				LoadSaveButton.GetComponent<Button>().interactable = false;
			}
			LoadSaveButton = GameObject.Find("Continue Last Save Button");
			if (SaveLoad.numSaves == 0)
			{
				LoadSaveButton.GetComponent<Button>().interactable = false;
			}
		}
	}

	public void LoadBySceneName(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void LoadBySceneIndex(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}

	public void LoadSaveScene()
	{
		if (SaveLoad.DoSavesExist())
		{
			SceneManager.LoadScene("Load Save Scene");
		}
	}

	public void LoadSave(bool loadLast)
	{
		if (loadLast || GlobalVariables.CurrentSaveProfile == null)
		{//loading the last save, or if the current save isn't selected yet, load the last save anyways
			if(GlobalVariables.GlobalSaveData.LastSavedGameName == "")
			{
				SaveGameFile saveFile = SaveLoad.LoadFirstSave();
				GlobalVariables.CurrentSaveProfile = saveFile;
				GlobalVariables.GlobalSaveData.LastSavedGameName = saveFile.SaveGameName;
			}
			else
			{
				GlobalVariables.CurrentSaveProfile = SaveLoad.LoadGame(GlobalVariables.GlobalSaveData.LastSavedGameName);
			}
		}
		SceneManager.LoadScene("Testing Scene");//The correct save is loaded into GlobalVariables.CurrentSaveProfile
	}

	public void Quit()
	{
		#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
		#else
				Application.Quit();
		#endif
	}
}