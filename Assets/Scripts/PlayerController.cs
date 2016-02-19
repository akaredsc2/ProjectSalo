using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Walking and jumping
	public float playerSpeed;
	public float jumpForce;

	//Ground check fields
	public Transform groundCheck;
	public LayerMask groundLayer;

	//Climbing ladders
	public bool isOnLadder;
	public float ladderClimdSpeed;

	private Rigidbody2D rb;
	private SpriteRenderer rend;

	private bool isGrounded;
	private float groundCheckRadius;

	//Save gravity scale for ladder climbing
	private float gravityScale;

	private Vector2 playerDirection;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rend = GetComponent<SpriteRenderer> ();

		groundCheckRadius = 0.35f;

		gravityScale = rb.gravityScale;

		playerDirection = new Vector2 ();
	}

	void Update() {
		if (isGrounded && Input.GetButtonDown ("Jump")) {
			rb.AddForce (Vector2.up * jumpForce);
		}
	}

	void FixedUpdate() {
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);

		float horizontal = Input.GetAxisRaw ("Horizontal");

		//Flip player sprite according to movement direction
		if (horizontal != 0) {
			rend.flipX = horizontal < 0;
		}

		//Does not allow player to stack in wall if he holds move button while falling
		if (!isGrounded && rb.IsTouchingLayers (groundLayer)) {
			playerDirection.Set (0, rb.velocity.y);
		} else {
			playerDirection.Set (horizontal * playerSpeed, rb.velocity.y);
		}

		if (isOnLadder) {
			rb.gravityScale = 0f;
			float vertical = Input.GetAxisRaw ("Vertical");
			playerDirection.y = vertical * ladderClimdSpeed;
		}
		if (!isOnLadder) {
			rb.gravityScale = this.gravityScale;
		}

		//rb.gravityScale = isOnLadder ? 0f : this.gravityScale;
		rb.velocity = playerDirection;
	}
}
