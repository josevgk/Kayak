using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterOfTime : MonoBehaviour {
//	public float timer;
	public Text crono;
	private float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
//		timer += Time.deltaTime;
		float timerControl = Time.time - startTime;
		string mins = ((int)timerControl/60).ToString("00");
		string segs = (timerControl % 60).ToString("00");
		string milisegs = ((timerControl * 100)%100).ToString ("00");

		string TimerString = string.Format ("{00}:{01}:{02}", mins, segs, milisegs);

		crono.text = TimerString.ToString ();

			
	}

//	void OnGUI() {
//		int minutes = Mathf.FloorToInt(timer / 60F);
//		int seconds = Mathf.FloorToInt(timer - minutes * 60);
//		string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
//
//		GUI.Label(new Rect(10,10,250,100), timer.ToString());
//	}
}
