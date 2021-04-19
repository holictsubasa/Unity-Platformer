using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MataPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
	}

}
