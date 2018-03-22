using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MoveKayak : MonoBehaviour {
	public GameObject kayak;
	public GameObject paddle;
	public Text marchatext;
	public Text meters;
	float inicialY; 
	Vector3 inicialPosition;
	public enum Marcha { Parado, Primera, Segunda, Tercera, Cuarta }
	private Marcha marcha;
	private float timerRapidoOld=0f;
	private float timerRapidoNew=0f;
	private float timerControl;
	private bool bloqueomarcha, aDerecha;
	private float rounded;
	public static bool onlyCrono, pausa;
	// Use this for initialization
	void Start () {
		inicialY = kayak.transform.position.y;
		inicialPosition = kayak.transform.position;
		kayak.transform.position = new Vector3 (kayak.transform.position.x, inicialY, kayak.transform.position.z);
		marcha = Marcha.Parado;
		marchatext.text="Parado";
		bloqueomarcha = false;
		aDerecha = false;
		meters.text="0";
		rounded = 0f;
		pausa = false;
	}
	
	// Update is called once per frame
	void Update () {
		

		if (onlyCrono == false && pausa==false) {
			//Tiempo de juego
			timerControl = Time.time;

			//Distancia recorrida
			float distance = (Vector3.Distance (inicialPosition, kayak.transform.position)) / 2;
			rounded = (float)(Math.Round ((double)distance, 2));
			meters.text = rounded.ToString ("N");

			//Saber cuando se mueve y a que velocidad
			float multX = Input.acceleration.x * Input.acceleration.x;
			float multY = Input.acceleration.y * Input.acceleration.y;
			float multZ = Input.acceleration.z * Input.acceleration.z;
			float sum = multX + multY + multZ;
			float raiz = Mathf.Sqrt (sum);
			float velocity = raiz - 1f;




			//Cuando haces movimiento con el móvil
			if (velocity>0.1) {	
				switch (marcha) {
				case Marcha.Parado:
					kayak.gameObject.transform.Translate (0.1f, 0f, 0f);
					if (!aDerecha) {
						if (paddle.transform.localRotation.y > -0.14) {
							aDerecha = true;
						} else {
							paddle.transform.Rotate (2.5f, 0f, 0f);
						}
					}
					if (aDerecha) {
						if (paddle.transform.localRotation.y < -0.51) {
							aDerecha = false;
						} else {
							paddle.transform.Rotate (-2.5f, 0f, 0f);
						}
					}

					break;
				case Marcha.Primera:
					kayak.gameObject.transform.Translate (0.3f, 0f, 0f);
					if (!aDerecha) {
						if (paddle.transform.localRotation.y > -0.14) {
							aDerecha = true;
						} else {
							paddle.transform.Rotate (3f, 0f, 0f);
						}
					}
					if (aDerecha) {
						if (paddle.transform.localRotation.y < -0.51) {
							aDerecha = false;
						} else {
							paddle.transform.Rotate (-3f, 0f, 0f);
						}
					}
					break;
				case Marcha.Segunda:
					kayak.gameObject.transform.Translate (0.4f, 0f, 0f);
					if (!aDerecha) {
						if (paddle.transform.localRotation.y > -0.14) {
							aDerecha = true;
						} else {
							paddle.transform.Rotate (4f, 0f, 0f);
						}
					}
					if (aDerecha) {
						if (paddle.transform.localRotation.y < -0.51) {
							aDerecha = false;
						} else {
							paddle.transform.Rotate (-4f, 0f, 0f);
						}
					}
					break;
				case Marcha.Tercera:
					kayak.gameObject.transform.Translate (0.5f, 0f, 0f);
					if (!aDerecha) {
						if (paddle.transform.localRotation.y > -0.14) {
							aDerecha = true;
						} else {
							paddle.transform.Rotate (5f, 0f, 0f);
						}
					}
					if (aDerecha) {
						if (paddle.transform.localRotation.y < -0.51) {
							aDerecha = false;
						} else {
							paddle.transform.Rotate (-5f, 0f, 0f);
						}
					}
					break;
				case Marcha.Cuarta:
					kayak.gameObject.transform.Translate (0.8f, 0f, 0f);
					if (!aDerecha) {
						if (paddle.transform.localRotation.y > -0.14) {
							aDerecha = true;
						} else {
							paddle.transform.Rotate (7f, 0f, 0f);
						}
					}
					if (aDerecha) {
						if (paddle.transform.localRotation.y < -0.51) {
							aDerecha = false;
						} else {
							paddle.transform.Rotate (-7f, 0f, 0f);
						}
					}
					break;
				}
				//Bajar de marcha cuando no vas suficientemente rapido
				if (velocity < 0.6) {
					Bajar (timerControl);
					//Capturar cuando vas muy rapido y poder subir de marcha
				} else {
					if (timerRapidoOld == 0f) {
						timerRapidoOld = Time.time;
						timerRapidoNew = Time.time;
					} else {
						timerRapidoOld = timerRapidoNew;
						timerRapidoNew = Time.time;
					}
					if ((timerRapidoNew - timerRapidoOld) < 2f && bloqueomarcha == false) {
						StartCoroutine ("Subir");
					}
				}

				//Cuando esta parado
			} else {
				BajarParado (timerControl);
				switch (marcha) {
				case Marcha.Primera:
					kayak.gameObject.transform.Translate (0.2f, 0f, 0f);
					break;
				case Marcha.Segunda:
					kayak.gameObject.transform.Translate (0.3f, 0f, 0f);
					break;
				case Marcha.Tercera:
					kayak.gameObject.transform.Translate (0.4f, 0f, 0f);
					break;
				case Marcha.Cuarta:
					kayak.gameObject.transform.Translate (0.5f, 0f, 0f);
					break;
				}
			}

		}






	}
		
	private void Bajar(float timer){

		switch (marcha) {
			case Marcha.Primera:
				if (timer - timerRapidoNew > 3f) {
					marchatext.text = "Parado";
					marcha = Marcha.Parado;
					timerRapidoNew = Time.time;
					
				}
				
				break;
			case Marcha.Segunda:
				if (timer - timerRapidoNew > 3f) {
					marcha = Marcha.Primera;
					marchatext.text = "Primera Marcha";
					timerRapidoNew = Time.time;
				}
					
				break;
			case Marcha.Tercera:
				if (timer - timerRapidoNew > 2.5f) {
					marcha = Marcha.Segunda;
					marchatext.text = "Segunda Marcha";
					timerRapidoNew = Time.time;
				}
				break;
			case Marcha.Cuarta:
				if (timer - timerRapidoNew > 2f) {
					marcha = Marcha.Tercera;
					marchatext.text = "Tercera Marcha";
					timerRapidoNew = Time.time;
				}
					
				break;
				}


	}

	private void BajarParado(float timer){
		switch (marcha) {
		case Marcha.Primera:
			if (timer - timerRapidoNew > 0.7f) {
				marchatext.text = "Parado";
				marcha = Marcha.Parado;
				timerRapidoNew = Time.time;

			}

			break;
		case Marcha.Segunda:
			if (timer - timerRapidoNew > 0.6f) {
				marcha = Marcha.Primera;
				marchatext.text = "Primera Marcha";
				timerRapidoNew = Time.time;
			}

			break;
		case Marcha.Tercera:
			if (timer - timerRapidoNew > 0.4f) {
				marcha = Marcha.Segunda;
				marchatext.text = "Segunda Marcha";
				timerRapidoNew = Time.time;
			}
			break;
		case Marcha.Cuarta:
			if (timer - timerRapidoNew > 0.2f) {
				marcha = Marcha.Tercera;
				marchatext.text = "Tercera Marcha";
				timerRapidoNew = Time.time;
			}

			break;
		}


	}

	IEnumerator Subir(){

		switch (marcha) {
		case Marcha.Parado:
			marchatext.text="Primera Marcha";
			marcha = Marcha.Primera;
			break;
		case Marcha.Primera:
			marchatext.text="Segunda Marcha";
			marcha = Marcha.Segunda;
			break;
		case Marcha.Segunda:
			marcha = Marcha.Tercera;
			marchatext.text="Tercera Marcha";
			break;
		case Marcha.Tercera:
			marcha = Marcha.Cuarta;
			marchatext.text="Cuarta Marcha";
			break;
		}
		bloqueomarcha = true;
		yield return new WaitForSeconds (1f);
		bloqueomarcha = false;
	}
}
