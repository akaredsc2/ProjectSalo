using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float playerSpeed;
	public float jumpForce;

	//Ground check fields
	public Transform groundCheck;
	public LayerMask groundLayer;

	private Rigidbody2D rb;
	private SpriteRenderer rend;

	private bool isGrounded;
	private float groundCheckRadius = 0.2f;

	private Vector2 playerDirection;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rend = GetComponent<SpriteRenderer> ();
		playerDirection = new Vector2 ();
	}

	void Update() {
		if (isGrounded && Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce (Vector2.up * jumpForce);
		}
	}

	void FixedUpdate() {
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);

		float horizontal = Input.GetAxis ("Horizontal");

		if (horizontal != 0) {

			//Flip player sprite according to movement direction
			rend.flipX = horizontal < 0;

			//Does not allow player to stack in wall if he holds move button while falling
			if (isGrounded) {
				playerDirection.Set (horizontal * playerSpeed, rb.velocity.y);
				rb.velocity = playerDirection;
			} else {
				rb.AddForce (Vector2.down);
			}

		}
	}
}
