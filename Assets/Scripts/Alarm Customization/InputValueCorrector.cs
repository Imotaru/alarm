using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputValueCorrector : MonoBehaviour {

	InputField myInput;
	void Awake(){
		myInput = this.GetComponentInParent<InputField>();
	}

	// Gets called OnValueChanged of the hour input field.
	public void ValidateHourValue(){
		ValidateValue(24);
	}

	// Gets called OnValueChanged of the minute input field.
	public void ValidateMinuteValue(){
		ValidateValue(60);
	}

	// Will reset the input field if the value is negative, not a digit, or larger than the maximum allowed value.
	void ValidateValue(int maxAmount){
		int parseTest = -1;
		int.TryParse(myInput.text, out parseTest);
		if(((parseTest < 0)  || (parseTest == 0) && (!myInput.text.StartsWith("0"))) || (parseTest >= maxAmount)){
			myInput.text = "";
		}
	}
}