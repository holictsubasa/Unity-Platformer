using UnityEngine;
using System.Collections;

public class MataEnemigo : MonoBehaviour {

	public GameObject ObjetoaMatar;
	public GameObject pisoaux;

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			Destroy(ObjetoaMatar.gameObject);
			pisoaux.SetActive (true);
		}
	}
}