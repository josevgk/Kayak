using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CounterOfDistance : MonoBehaviour {
	public Text meters;
	private float mult=0;
	// Use this for initialization
	void Start () {
		meters.text="0";
	}
	
	// Update is called once per frame
	void Update () {
		float multX = Input.acceleration.x * Input.acceleration.x;
		float multY = Input.acceleration.y * Input.acceleration.y;
		float multZ = Input.acceleration.z * Input.acceleration.z;
		float sum = multX + multY + multZ;
		float raiz = Mathf.Sqrt (sum);
		float velocity = raiz-1f;
		float rounded;
		if (velocity > 0.1f && velocity < 0.6f) {
			mult += velocity * 0.5f;
			rounded = (float)(Math.Round ((double)mult, 2));
			meters.text = rounded.ToString ("N");
		} else if (velocity > 0.6) {
			mult += 0.6f;
			rounded = (float)(Math.Round ((double)mult, 2));
			meters.text = rounded.ToString ("N");
		}
	}
}
