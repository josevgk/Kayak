using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FotoCrono : MonoBehaviour , TimedInputHandler {
	public GameObject volver, entrenamiento, velo, veloresi, resi;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void HandlerTimedInput(){
		volver.SetActive (true);
		gameObject.SetActive (false);
		entrenamiento.SetActive (false);
		velo.SetActive (true);
		veloresi.SetActive (true);
		resi.SetActive (true);
	}
}
