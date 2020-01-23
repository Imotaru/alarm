using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LapButton : MonoBehaviour {

	public Button mainButton;
	public Button btn;


	public void Start(){
		btn.onClick.AddListener(IsClicked);
	}

	// Pauses the currently selected clock and sets it's time to 0.
	public void IsClicked(){
		mainButton.GetComponentInChildren<MainButton>().stopwatchValue = 0f;
		mainButton.GetComponentInChildren<MainButton>().SetRunningStateOfCurrentlySelected(false);
	}
}
