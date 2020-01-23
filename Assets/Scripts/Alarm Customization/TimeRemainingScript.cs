using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRemainingScript : MonoBehaviour {
	public InputField hour, minute;
	int hourInput, minuteInput;

	// Updates the time remaining text under the time selector in the customization menu.
	void Update () {
		// for max efficiency, the parsing could be done on value change of the inputs
		// the rest has to be in update though because time still passes even if the values don't change

		int.TryParse(hour.text, out hourInput);
		int.TryParse(minute.text, out minuteInput);

		int minuteDifference = minuteInput - System.DateTime.Now.Minute;
		int hourDifference = hourInput - System.DateTime.Now.Hour;
		
		if(hourDifference < 0){
			hourDifference = 24 - System.DateTime.Now.Hour + hourInput;
		}
		if(minuteDifference < 0){
			minuteDifference = 60 - System.DateTime.Now.Minute + minuteInput;
			hourDifference--;
		}
		if(hourDifference < 0){
			hourDifference = 23;
		}

		this.GetComponentInParent<Text>().text = "Alarm will go off in " + hourDifference + "h " + minuteDifference + "m";
	}
}
