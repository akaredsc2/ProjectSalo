using UnityEngine;
using System.Collections;

public class LadderScript : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name.Equals("Player")) {
			player.isOnLadder = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name.Equals ("Player")) {
			player.isOnLadder = false;
		}
	}
}
