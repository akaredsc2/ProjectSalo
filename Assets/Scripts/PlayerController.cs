using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float playerSpeed;
	public float jumpForce;

	public Transform topLeft;
	public Transform bottomRight;
	public LayerMask groundLayers;

	private Rigidbody2D rb;
	private SpriteRenderer rend;


	public bool isGrounded;
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

		isGrounded = Physics2D.OverlapArea(topLeft.position, bottomRight.position, groundLayers);  

		if (isGrounded) {
			vertical = Input.GetAxisRaw ("Jump") * jumpForce;
		}

		if ( horizontal != 0 || vertical != 0) {

			rend.flipX = horizontal < 0;

			playerDirection.Set (horizontal, vertical);
			rb.AddForce (playerDirection * playerSpeed);
		}

	}
}
