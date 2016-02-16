using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float playerSpeed;

	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
		
	void Update () {
		
	}

	void FixedUpdate() {
		float horizontal = Input.GetAxisRaw ("Horizontal");

		rb.AddForce (Vector2.right * horizontal * playerSpeed);
	}
}
