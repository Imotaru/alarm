using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseTimeButtonScript : MonoBehaviour {

	public Button mainButton;
	public Button btn;

	public void Start(){
		btn.onClick.AddListener(IsClicked);
	}


	// Increases the main button's currently selected timer by 15 seconds.
	public void IsClicked(){
		mainButton.GetComponentInChildren<MainButton>().AddToCurrentClock(15f);
	}
}
