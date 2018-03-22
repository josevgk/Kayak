using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipoContrarreloj : MonoBehaviour {
	public static TipoContrarreloj tipoContrarreloj;
	public static string titulo,textoCrono;
	public static float segundos;
	void Awake(){
		if (tipoContrarreloj == null) {
			tipoContrarreloj = this;
			DontDestroyOnLoad (gameObject);
		} else if (tipoContrarreloj != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
