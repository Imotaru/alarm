using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeModeToggle : MonoBehaviour {

	bool stopwatchMode = true;
	public Image background;
	public Button lapButton;
	public Button mainButton;

	// Toggles between stopwatch mode and timer mode, showing the other timer (that is still running in the background). Makes the Lap button appear and disappear accordingly.
	public void Toggle(){
		stopwatchMode = !stopwatchMode;
		Vector3 newPos = background.transform.position;

		if(stopwatchMode){
			newPos.x -= 44;
			lapButton.enabled = true;
			lapButton.GetComponentInChildren<Text>().text = "LAP";
			lapButton.GetComponentInChildren<Image>().enabled = true;
		}else{
			newPos.x += 44;
			lapButton.enabled = false;
			lapButton.GetComponentInChildren<Text>().text = "";
			lapButton.GetComponentInChildren<Image>().enabled = false;
		}
		background.transform.SetPositionAndRotation(newPos, background.transform.rotation);
		mainButton.GetComponent<MainButton>().UpdateButtonGraphics();
	}

	// Returns whether the stopwatch is currently selected, returns false if the timer is currently selected.
	public bool IsInStopwatchMode(){
		return stopwatchMode;
	}
}
