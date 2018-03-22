using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FotoResistencia : MonoBehaviour , TimedInputHandler {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void HandlerTimedInput(){
		TipoContrarreloj.titulo = "Resistencia";
		TipoContrarreloj.segundos = 180f;
		TipoContrarreloj.textoCrono = "03:00:00";
		SceneManager.LoadScene("Contrarreloj");
	}
}
