using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FotoVolver : MonoBehaviour , TimedInputHandler {
	public GameObject resi, veloresi, velo, crono, libre;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void HandlerTimedInput(){
		resi.SetActive (false);
		veloresi.SetActive (false);
		velo.SetActive (false);
		crono.SetActive (true);
		libre.SetActive (true);
		gameObject.SetActive (false);
	}
}
