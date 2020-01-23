using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CancelButtonScript : MonoBehaviour {
	public GameObject windowManager;
	public Button btn;

	public void Start(){
		btn.onClick.AddListener(IsClicked);
	}


	// Closes the customization menu without making any changes.
	public void IsClicked(){
		windowManager.GetComponent<WindowManagerScript>().CloseCustomizationMenu();
	}
}
