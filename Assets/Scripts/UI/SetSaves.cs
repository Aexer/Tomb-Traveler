using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSaves : MonoBehaviour
{
	private Dropdown saveDropdown;
	private List<SaveGameFile> SavedGames;
	
	void Start ()
	{
		saveDropdown = GetComponent<Dropdown>();

		List<Dropdown.OptionData> SavesOptions = new List<Dropdown.OptionData>();
		SavedGames = SaveLoad.LoadAllSaves();
		
		foreach(SaveGameFile save in SavedGames)
		{
			SavesOptions.Add(new Dropdown.OptionData(save.SaveGameName));
		}

		saveDropdown.options = SavesOptions;

		saveDropdown.onValueChanged.AddListener(delegate {
			DropdownValueChanged(saveDropdown);
		});
	}
	
	void DropdownValueChanged(Dropdown change)//Changes the save to load at the start of gameplay
	{
		GlobalVariables.CurrentSaveProfile = SavedGames[change.value];
	}
}
