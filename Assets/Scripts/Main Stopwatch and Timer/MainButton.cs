using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButton : MonoBehaviour {

	public Button btn;
	public Button timeModeToggler;
	public Button mainButton;
	public Image pauseImage;
	public Text timeText;

	public AudioSource alarmSound;

	bool stopwatchRunning = false;
	bool timerRunning = false;
	public float stopwatchValue = 0f;
	public float timerValue = 0f;

	public void Start(){
		btn.onClick.AddListener(IsClicked);
	}

	// Plays or pauses the currently selected clock.
	public void IsClicked(){
		if(timeModeToggler.GetComponent<TimeModeToggle>().IsInStopwatchMode()){
			SetRunningStateOfCurrentlySelected(!stopwatchRunning);
		}else{
			SetRunningStateOfCurrentlySelected(!timerRunning);
		}
	}

	// Progresses the running timers and sets off any actions that they might do.
	void Update(){
		if(stopwatchRunning){
			stopwatchValue += Time.deltaTime;
		}
		if(timerRunning){
			timerValue -= Time.deltaTime;
			if(timerValue < 0){
				// If the countdown timer reaches 0, an alarm sound plays and the timer is set to 0 and paused.
				if(!alarmSound.isPlaying){
        			alarmSound.Play(0);
				}
				timerValue = 0f;
				timerRunning = false;
				UpdateButtonGraphics();
			}
		}
		UpdateTimeText();
	}

	// Plays or pauses the currently selected clock. (TODO, is this check redundant? it seems like something similar is happening in IsClicked()).
	public void SetRunningStateOfCurrentlySelected(bool state){
		if(timeModeToggler.GetComponent<TimeModeToggle>().IsInStopwatchMode()){
			stopwatchRunning = state;
		}else{
			timerRunning = state;
		}
		UpdateButtonGraphics();
	}

	// Updates the graphics of the pause/play button.
	public void UpdateButtonGraphics(){
		if((timeModeToggler.GetComponent<TimeModeToggle>().IsInStopwatchMode() && stopwatchRunning)
		|| (!timeModeToggler.GetComponent<TimeModeToggle>().IsInStopwatchMode() && timerRunning)){
			mainButton.image.enabled = false;
			pauseImage.enabled = true;
		} else{
			mainButton.image.enabled = true;
			pauseImage.enabled = false;
		}
	}

	// Updates the text of the currrently visible timer and displays them in a format that makes sense.
	// FIXME? this might be broken for higher values (hundreds or thousands of hours), needs testing.
	void UpdateTimeText(){
		timeText.text = "";
		if(timeModeToggler.GetComponent<TimeModeToggle>().IsInStopwatchMode()){
				// hours
			if(stopwatchValue >= 60*60){
				if(((int) stopwatchValue / 60*60) < 10){
					timeText.text += "0";
				}
				timeText.text += ((int) stopwatchValue / (60*60)) + ":";
			}
				// minutes
			if(((int) (stopwatchValue % (60*60)) / 60) < 10){
				timeText.text += "0";
			}
			timeText.text += ((int) (stopwatchValue % (60*60)) / 60) + ":";
				// seconds
			if(((int) stopwatchValue % 60) < 10){
				timeText.text += "0";
			}
			timeText.text += (int) stopwatchValue % 60;

		}else{
				// hours
			if(timerValue >= 60*60){
				if(((int) timerValue / 60*60) < 10){
					timeText.text += "0";
				}
				timeText.text += ((int) timerValue / (60*60)) + ":";
			}
				// minutes
			if(((int) (timerValue % (60*60)) / 60) < 10){
				timeText.text += "0";
			}
			timeText.text += ((int) (timerValue % (60*60)) / 60) + ":";
				// seconds
			if(((int) timerValue % 60) < 10){
				timeText.text += "0";
			}
			timeText.text += (int) timerValue % 60;
		}
	}

	// Adds the specified value to the currently selected clock.
	public void AddToCurrentClock(float amount){
		if(timeModeToggler.GetComponent<TimeModeToggle>().IsInStopwatchMode()){
			stopwatchValue += amount;
		}else{
			timerValue += amount;
		}
	}

}
