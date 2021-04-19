using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControladorMatt : MonoBehaviour {
	public float walkSpeed;
	public float jumpImpulse;

	public Transform groundCheckPoint;
	public LayerMask whatIsGround;

	private Rigidbody2D body;
	private Vector2 movement;

	private float horInput;
	private bool jumpInput;

	private bool iAmInTheGround;
	private bool facingRight = true;

	private Animator anim;

	// Use this for initialization
	void Start () {
		this.body = this.GetComponent<Rigidbody2D> ();
		this.movement = new Vector2 (); 
		this.iAmInTheGround = false;

		this.anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.horInput = Input.GetAxis ("Horizontal");
		this.jumpInput = Input.GetKey (KeyCode.Space);

		if ((this.horInput < 0) && (this.facingRight)) {
			this.Flip ();
			this.facingRight = false;
		} else if ((this.horInput > 0) && (!this.facingRight)) {
			this.Flip ();
			this.facingRight = true;
		}

		this.anim.SetFloat ("HorSpeed", Mathf.Abs(this.horInput));

		if (Physics2D.OverlapCircle (this.groundCheckPoint.position, 0.2f, this.whatIsGround)) {
			this.iAmInTheGround = true;
		}else{
			this.iAmInTheGround = false;

		}
	}

	void FixedUpdate(){
		this.movement = this.body.velocity;

		this.movement.x = horInput * walkSpeed;
		if (this.jumpInput && this.iAmInTheGround) {
			this.movement.y = jumpImpulse;
		}

		if (!this.iAmInTheGround) {
			this.anim.SetBool ("Jump", true);
			if (this.movement.y < -7) {
				this.movement.y = -7;
			}
		} else {
			this.anim.SetBool ("Jump", false);
		}


		this.body.velocity = this.movement;
	}


	void Flip(){
		Vector3 scale = this.transform.localScale;
		scale.x *= -1;
		this.transform.localScale = scale;
	}
}
 