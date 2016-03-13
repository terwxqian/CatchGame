using UnityEngine;
using System.Collections;

public class HatController : MonoBehaviour {

	public Camera cam;
	private Rigidbody2D rb2D;
	private float maxWidth;
	private Renderer rend;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}

		rb2D = GetComponent<Rigidbody2D> ();
		rend = GetComponent<Renderer> ();

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0f);

		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner );

		float hatWidth = rend.bounds.extents.x; 

		maxWidth = targetWidth.x - hatWidth;
	}
	
	// Update is called once per physics timestep (that can be set in Edit/Physics)
	void FixedUpdate () {
		Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition );
		Vector3 targetPosition = new Vector3 (rawPosition.x, 0f, 0f);
		float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
		targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
		rb2D.MovePosition (targetPosition);
	}
}
