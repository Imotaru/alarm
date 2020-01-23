using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmToggle : MonoBehaviour {
	public Sprite buttonEnabled;
	public Sprite buttonDisabled;
	public Button myButton;

	bool alarmToggle = true;

	public void Start(){
		myButton.onClick.AddListener(IsClicked);
	}

	// On toggle, change the sprite and alarmToggle value.
	public void IsClicked(){
		if(myButton.image.sprite == buttonEnabled){
			myButton.image.sprite = buttonDisabled;
			alarmToggle = false;
		} else{
			myButton.image.sprite = buttonEnabled;
			alarmToggle = true;
		}
	}

	// Returns whether or not the alarm is toggled.
	public bool GetToggle(){
		return alarmToggle;
	}

}
