using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FotoVelocidadResistencia : MonoBehaviour , TimedInputHandler {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void HandlerTimedInput(){
		TipoContrarreloj.titulo = "Velocidad-Resistencia";
		TipoContrarreloj.segundos = 120f;
		TipoContrarreloj.textoCrono = "02:00:00";
		SceneManager.LoadScene("Contrarreloj");
	}
}
