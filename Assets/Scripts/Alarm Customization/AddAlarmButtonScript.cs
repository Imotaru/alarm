using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddAlarmButtonScript : MonoBehaviour {
	public GameObject windowManager;
	WindowManagerScript wms;
	public Button btn;
	void Start () {
		btn.onClick.AddListener(IsClicked);
		wms = windowManager.GetComponent<WindowManagerScript>();
	}

	// Opens the customization menu and turns off editing mode.
	public void IsClicked(){
		wms.OpenCustomizationMenu();
		wms.SetEditingMode(false);
	}
}