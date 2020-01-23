using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmSorter : MonoBehaviour {
	public GameObject parent;
	AlarmScript[] alarms;

	// Sorts the alarms using a simple bubble sort algorithm
	public void SortAlarms(){
		bool done = false;
		while(!done){
			alarms = parent.GetComponentsInChildren<AlarmScript>();
			done = true;
			for (int i = 0; i < alarms.Length-1; i++){
				if(alarms[i].CompareAlarmTimes(alarms[i+1]) == 1){
					alarms[i].transform.SetSiblingIndex(i+1);
					done = false;
				}
			}
		}
	}
}