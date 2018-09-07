using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSaves : MonoBehaviour
{
	private Dropdown saveDropdown;
	
	void Start ()
	{
		saveDropdown = GetComponent<Dropdown>();
		saveDropdown.onValueChanged.AddListener(delegate {
			DropdownValueChanged(saveDropdown);
		});
		//set saves
	}
	
	void DropdownValueChanged(Dropdown change)//Changes the save to load at the start of gameplay
	{
		GlobalVariables.CurrentSaveProfile = change.itemText.text;
	}
}
