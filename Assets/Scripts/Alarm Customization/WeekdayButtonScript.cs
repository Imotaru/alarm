using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeekdayButtonScript : MonoBehaviour{

    Color activeColor = new Color(1f, 1f, 1f, 1f);
    Color inactiveColor = new Color(0.5f, 0.5f, 0.5f, 1f);

    bool weekdaySelected;
    public Button btn;

    public void Start(){
		btn.onClick.AddListener(IsClicked);
    }

    // Flips the selection of this weekday button.
    public void IsClicked(){
        SetWeekday(!weekdaySelected);
    }

    // Sets the weekdaySelected value and changes the color of the button.
    public void SetWeekday(bool c){
        weekdaySelected = c;
		if (weekdaySelected){
            this.GetComponentInChildren<Image>().color = activeColor;
        }
        else{
            this.GetComponentInChildren<Image>().color = inactiveColor;
        }
    }

    // Returns whether or not this weekday button is selected.
    public bool WeekdayIsSelected(){
        return weekdaySelected;
    }
}