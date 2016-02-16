using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float playerSpeed;

	private Rigidbody2D rb;
	private SpriteRenderer rend;

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
		float vertical = Input.GetAxisRaw ("Jump");

		if ( horizontal != 0 || vertical != 0) {

			rend.flipX = horizontal < 0;

			playerDirection.Set (horizontal, vertical);
			rb.AddForce (playerDirection * playerSpeed);
		}

	}
}
