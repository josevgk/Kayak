using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonacionElementos : MonoBehaviour {
	public GameObject kayak, water, island, paraiso1, paraiso2;
	private float inicial;
	private int vezClon;
	// Use this for initialization
	void Start () {
		inicial = kayak.transform.position.z;
	}

	// Update is called once per frame
	void Update () {
		if (kayak.transform.position.z - inicial > 1500) {
			vezClon++;
			if (vezClon % 3 == 0) {
				//Clonar
				Instantiate (island, new Vector3(island.transform.position.x, island.transform.position.y, kayak.transform.position.z+2000f),Quaternion.identity);
				inicial = kayak.transform.position.z;
			} else {
				Instantiate (paraiso1, new Vector3 (paraiso1.transform.position.x, paraiso1.transform.position.y, kayak.transform.position.z+1500f),Quaternion.identity);
				Instantiate (paraiso2, new Vector3 (paraiso2.transform.position.x, paraiso2.transform.position.y, kayak.transform.position.z+1500f),Quaternion.identity);
				Instantiate (water, new Vector3 (water.transform.position.x, water.transform.position.y, kayak.transform.position.z+1500f),Quaternion.identity);
				inicial = kayak.transform.position.z;
			}
		}
		
	}
}
