﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Cambionnvl2 : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			SceneManager.LoadScene("Nivel3");
		}
	}
}
