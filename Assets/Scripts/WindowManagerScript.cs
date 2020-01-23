using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowManagerScript : MonoBehaviour {

	public static WindowManagerScript Instance{get; private set; }
	public GameObject customizationMenu;

	public InputField hourField;
	public InputField minuteField;
	public Button[] weekdayButtons;
	public GameObject alarmContainer;
	bool editingMode;

	private void Awake(){
		if(Instance == null){
			Instance = this;
		} else{
			Destroy(gameObject);
		}
	}

	// Opens the customization menu, the main screen remains loaded in the background.
	public void OpenCustomizationMenu(){
		customizationMenu.SetActive(true);
		hourField.text = "";
		minuteField.text = "";

		if(System.DateTime.Now.Hour+1 < 10){
			hourField.text = "0";
		}
		if(System.DateTime.Now.Minute < 10){
			minuteField.text = "0";
		}
		hourField.text += (System.DateTime.Now.Hour+1).ToString();
		minuteField.text += System.DateTime.Now.Minute.ToString();
		for(int i = 0; i < weekdayButtons.Length; i++){
			weekdayButtons[i].GetComponent<WeekdayButtonScript>().SetWeekday(false);
		}
	}

	// Closes the customization menu and untags any loaded alarm.
	public void CloseCustomizationMenu(){
		customizationMenu.SetActive(false);
		alarmContainer.GetComponentInChildren<AlarmSorter>().SortAlarms();
		try{
			GameObject.FindGameObjectWithTag("loaded").tag = "Untagged";
		} catch{}
	}

	// Returns whether editing mode is on or not.
	public bool IsInEditingMode(){
		return editingMode;
	}

	// Sets whether editing mode is on or not.
	public void SetEditingMode(bool editing){
		editingMode = editing;
	}

	// Loads an alarm's values into the UI
	public void LoadAlarm(AlarmScript alarm){
		editingMode = true;

		hourField.text = "";
		minuteField.text = "";
		if(alarm.GetHour() < 10){
			hourField.text += "0";
		}
		if(alarm.GetMinute() < 10){
			minuteField.text += "0";
		}
		hourField.text += alarm.GetHour().ToString();
		minuteField.text += alarm.GetMinute().ToString();
		for(int i = 0; i < weekdayButtons.Length; i++){
			weekdayButtons[i].GetComponent<WeekdayButtonScript>().SetWeekday(alarm.GetWeekdayState(i));
		}
	}

}
