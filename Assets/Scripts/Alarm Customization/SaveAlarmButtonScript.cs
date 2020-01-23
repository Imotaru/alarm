using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveAlarmButtonScript : MonoBehaviour {
	public GameObject windowManager;
	public GameObject alarmPrefab;

	public AlarmScript existingAlarm;
	public GameObject parent;

	// If editing mode is on, this creates a new alarm with the current settings, otherwise it saves the old alarm with the current changes, then it closes the customization menu.
	public void IsClicked(){
		if(!windowManager.GetComponent<WindowManagerScript>().IsInEditingMode()){
			GameObject newAlarm = (Instantiate(alarmPrefab));
			newAlarm.transform.SetParent(parent.transform);
			SaveChanges(newAlarm.GetComponentInChildren<AlarmScript>());
		} else{
			SetExistingAlarm();
			SaveChanges(existingAlarm);
		}
		windowManager.GetComponent<WindowManagerScript>().CloseCustomizationMenu();
	}

	// Finds the alarm that is being edited.
	public void SetExistingAlarm(){
		existingAlarm = GameObject.FindGameObjectWithTag("loaded").GetComponent<AlarmScript>();
	}

	// Saves the changes based on the states of the UI in the customization menu to the chosen alarm.
	public void SaveChanges(AlarmScript newAlarm){
			int newHour;
			int newMinute;
			int.TryParse(windowManager.GetComponentInChildren<WindowManagerScript>().hourField.text, out newHour);
			int.TryParse(windowManager.GetComponentInChildren<WindowManagerScript>().minuteField.text, out newMinute);

			newAlarm.GetComponentInChildren<AlarmScript>().SetHour(newHour);
			newAlarm.GetComponentInChildren<AlarmScript>().SetMinute(newMinute);

			for(int i = 0; i < 7; i++){
				// This sets the weekday state in the new alarm to the state of the corresponding button.
				newAlarm.GetComponentInChildren<AlarmScript>().SetWeekdayState(
					i, windowManager.GetComponentInChildren<WindowManagerScript>().weekdayButtons[i].GetComponentInChildren<WeekdayButtonScript>().WeekdayIsSelected());
			}
			string newWeekdayText = "";
			if(newAlarm.GetComponentInChildren<AlarmScript>().GetWeekdayState(0)){
				newWeekdayText += "Mon ";
			}
			if(newAlarm.GetComponentInChildren<AlarmScript>().GetWeekdayState(1)){
				newWeekdayText += "Tue ";
			}
			if(newAlarm.GetComponentInChildren<AlarmScript>().GetWeekdayState(2)){
				newWeekdayText += "Wed ";
			}
			if(newAlarm.GetComponentInChildren<AlarmScript>().GetWeekdayState(3)){
				newWeekdayText += "Thu ";
			}
			if(newAlarm.GetComponentInChildren<AlarmScript>().GetWeekdayState(4)){
				newWeekdayText += "Fri ";
			}
			if(newAlarm.GetComponentInChildren<AlarmScript>().GetWeekdayState(5)){
				newWeekdayText += "Sat ";
			}
			if(newAlarm.GetComponentInChildren<AlarmScript>().GetWeekdayState(6)){
				newWeekdayText += "Sun";
			}
			if(newWeekdayText == ""){
				newWeekdayText = "No repeat";
			}

			newAlarm.GetComponentInChildren<Text>().text = newWeekdayText;

	}
}
