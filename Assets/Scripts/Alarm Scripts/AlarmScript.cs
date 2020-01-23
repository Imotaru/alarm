using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmScript : MonoBehaviour {

	public Button btn;
	int hour = 13;
	int minute = 37;
	bool[] weekdays = {false, false, false, false, false, false, false};
	bool active;
	GameObject alarmSound;
	WindowManagerScript windowManagerScript;


	public void Start(){
		btn.onClick.AddListener(IsClicked);
	}


	// Returns this alarm's hour value.
	public int GetHour(){
		return hour;
	}

	// Sets this alarm's hour value to the specified value and updates the alarm time text, if it's valid.
	public void SetHour(int h){
		if(h >= 0 && h < 24){
			hour = h;
			UpdateTimeText();
		}
	}

	// Returns this alarm's minute value.
	public int GetMinute(){
		return minute;
	}

	// Sets this alarm's hour value to the specified value and updates the alarm time text, if it's valid.
	public void SetMinute(int m){
		if(m >= 0 && m < 60){
			minute = m;
			UpdateTimeText();
		}
	}

	// Updates the time text that appears on the alarm.
	void UpdateTimeText(){
		string newText = "";
		if(hour < 10){
			newText += "0";
		}
		newText += hour + ":";
		if(minute < 10){
			newText += "0";
		}
		newText += minute;
		this.GetComponentsInChildren<Text>()[1].text = newText;
	}

	// Returns whether the alarm is supposed to ring on the given day (0 = Monday, 1 = Tuesday, etc.).
	public bool GetWeekdayState(int index){
		return weekdays[index];
	}

	// Sets whether the alarm is supposed to ring on the given day (0 = Monday, 1 = Tuesday, etc.).
	public void SetWeekdayState(int index, bool state){
		weekdays[index] = state;
	}

	// Returns 1 if this alarm is later than the other alarm, 0 if they are equal, and -1 if this one is earlier.
	public int CompareAlarmTimes(AlarmScript alarm2){
		if(hour > alarm2.GetHour()){
			return 1;
		}
		if(hour == alarm2.GetHour()){
			if(minute > alarm2.GetMinute()){
				return 1;
			} else if(minute == alarm2.GetMinute()){
				return 0;
			}
		}
		return -1;
	}

	// Checks if right now is the time that is specified, if so it sounds the alarm (there is probably a more efficient way to do this that doesn't involve checking the time every frame for every alarm).
	void Update(){
		if(System.DateTime.Now.Hour == hour){
			if(System.DateTime.Now.Minute == minute){
				if((weekdays[0] && (System.DateTime.Now.DayOfWeek.ToString() == "Monday"))
				|| (weekdays[1] && (System.DateTime.Now.DayOfWeek.ToString() == "Tuesday"))
				|| (weekdays[2] && (System.DateTime.Now.DayOfWeek.ToString() == "Wednesday"))
				|| (weekdays[3] && (System.DateTime.Now.DayOfWeek.ToString() == "Thursday"))
				|| (weekdays[4] && (System.DateTime.Now.DayOfWeek.ToString() == "Friday"))
				|| (weekdays[5] && (System.DateTime.Now.DayOfWeek.ToString() == "Saturday"))
				|| (weekdays[6] && (System.DateTime.Now.DayOfWeek.ToString() == "Sunday"))){

					if(!alarmSound.GetComponent<AudioSource>().isPlaying && this.GetComponentInChildren<AlarmToggle>().GetToggle()){
						alarmSound.GetComponent<AudioSource>().Play();
					}
				}
			}
		}
	}

	// Finds windowManagerScript, finds alarmSound, sets itself to active (default state).
	void Awake(){
		windowManagerScript = FindObjectOfType<WindowManagerScript>();
		alarmSound = GameObject.FindGameObjectWithTag("sound");
		active = true;
	}

	// Opens customization menu and sets it up for editing the alarm.
	public void IsClicked(){
		windowManagerScript.OpenCustomizationMenu();
		this.gameObject.tag = "loaded";
		windowManagerScript.LoadAlarm(this);
	}

}
