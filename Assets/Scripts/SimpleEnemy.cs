using UnityEngine;
using System.Collections;

public class SimpleEnemy : MonoBehaviour {
	private float prevX;
	public int direccion;
	public float distancia;
	public float velocidad;

	// Use this for initialization
	void Start () {
		prevX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (direccion == 1) {
			if (prevX + distancia >= transform.position.x) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocidad,GetComponent<Rigidbody2D> ().velocity.y);
			} else {
				prevX = transform.position.x;
				direccion = -1;
				Vector3 theScale = transform.localScale;
				theScale.x = -theScale.x;
				transform.localScale = theScale;

			}
		} else {
			if (prevX - distancia <= transform.position.x) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-velocidad,GetComponent<Rigidbody2D> ().velocity.y);
			} else {
				prevX = transform.position.x;
				direccion = 1;
				Vector3 theScale = transform.localScale;
				theScale.x = -theScale.x;
				transform.localScale = theScale;

			}
		}
	}
}
