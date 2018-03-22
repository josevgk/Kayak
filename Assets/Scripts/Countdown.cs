using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
	public Text crono, distance, distanceScroll, tipo;
	public GameObject finalText, scroll, preparados, listos, ya, botonPausa;
	public static bool finish;
	private float startTime;
	public static bool inicio;
	// Use this for initialization
	void Start () {
		
		finish = false;
		finalText.SetActive (false);
		scroll.SetActive (false);
		crono.text = TipoContrarreloj.textoCrono;
		inicio = false;
		MoveKayak.onlyCrono = true;
		StartCoroutine ("Preparatoria");

	}
	
	// Update is called once per frame
	void Update () {
		if (inicio==true) {
			float timerControl = startTime - Time.time;
			if (timerControl > 0) {
				string mins = ((int)timerControl / 60).ToString ("00");
				string segs = (timerControl % 60).ToString ("00");
				string milisegs = ((timerControl * 100) % 100).ToString ("00");

				string timerString = string.Format ("{00}:{01}:{02}", mins, segs, milisegs);

				crono.text = timerString.ToString ();
			} else {
				crono.text = "00:00:00";
				if (finish == false) {
					finish = true;
					MoveKayak.onlyCrono = true;
					botonPausa.SetActive (false);
					StartCoroutine ("PanelFinal");
				}

			}
		}
	}

	IEnumerator PanelFinal(){
		string d = distance.text;
		finalText.SetActive (true);
		yield return new WaitForSeconds (5f);
		finalText.SetActive (false);
		scroll.SetActive (true);
		distanceScroll.text = "Distancia recorrida: " + d+" metros";
		tipo.text += TipoContrarreloj.titulo;
	}

	IEnumerator Preparatoria(){
		preparados.SetActive (true);
		yield return new WaitForSeconds (2f);
		preparados.SetActive (false);
		listos.SetActive (true);
		yield return new WaitForSeconds (2f);
		listos.SetActive (false);
		ya.SetActive (true);
		yield return new WaitForSeconds (1f);
		ya.SetActive (false);
		startTime = TipoContrarreloj.segundos+Time.time-1f;
		inicio = true;
		MoveKayak.onlyCrono = false;
	}
}
