using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour {
	public GameObject panel2;
	// Use this for initialization
	void Start () {
		panel2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pausa(){
		Time.timeScale = 0f;
		panel2.SetActive (true);
		MoveKayak.pausa = true;
	}

	public void Reanudar(){
		panel2.SetActive (false);
		MoveKayak.pausa = false;
		Time.timeScale = 1f;
	}

	public void Salir(){
		panel2.SetActive (false);
		MoveKayak.pausa = false;
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
	}

	public void Reiniciar(){
		panel2.SetActive (false);
		MoveKayak.pausa = false;
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
