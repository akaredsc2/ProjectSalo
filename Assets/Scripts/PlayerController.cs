using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float playerSpeed;
	public float jumpForce;

	private Rigidbody2D rb;
	private SpriteRenderer rend;


	private bool isGrounded;
	private Vector2 playerDirection;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rend = GetComponent<SpriteRenderer> ();
		playerDirection = new Vector2 ();
	}
		
	void Update () {
		
	}

	void FixedUpdate() {
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = 0;

		if (isGrounded) {
			vertical = Input.GetAxisRaw ("Jump") * jumpForce;
		}

		if ( horizontal != 0 || vertical != 0) {

			rend.flipX = horizontal < 0;

			playerDirection.Set (horizontal, vertical);
			rb.AddForce (playerDirection * playerSpeed);
		}

	}
		
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Platform") {
			isGrounded = true;
			Debug.Log ("Hello");
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Platform")
			isGrounded=false;
			Debug.Log ("Bye");
	}
}
