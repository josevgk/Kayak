using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FotoEntrenamiento : MonoBehaviour , TimedInputHandler {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void HandlerTimedInput(){
		SceneManager.LoadScene("Kayak");
	}
}
