using UnityEngine;
using System.Collections;

public class PlatformTiling : MonoBehaviour {

	private Material mat;
	private Vector2 locScale;

	void Start() {
		mat = GetComponent<Renderer> ().material;
		locScale = new Vector2 (transform.localScale.x, transform.localScale.y);
		mat.SetTextureScale ("_MainTex", locScale);
	}
}
