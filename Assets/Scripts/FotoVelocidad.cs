using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FotoVelocidad : MonoBehaviour , TimedInputHandler {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void HandlerTimedInput(){
		TipoContrarreloj.titulo = "Velocidad";
		TipoContrarreloj.segundos = 60f;
		TipoContrarreloj.textoCrono = "01:00:00";
		SceneManager.LoadScene("Contrarreloj");
	}
}
