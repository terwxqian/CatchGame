﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public Camera cam;
	private float maxWidth;
	private Renderer rend;

	public GameObject ball;

	public float timeLeft;

	public Text timerText;

	public GameObject gameOverText;
	public GameObject restartButton;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
			
		rend = ball.GetComponent<Renderer> ();

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0f);

		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner );

		float ballWidth = rend.bounds.extents.x; 

		maxWidth = targetWidth.x - ballWidth;

		StartCoroutine (Spawn ());

		UpdateText ();
	}

	void FixedUpdate(){
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0)
			timeLeft = 0;
		UpdateText ();
	}

	IEnumerator Spawn(){
		yield return new WaitForSeconds (2.0f);
		while (timeLeft > 0) {
			Vector3 spawnPosition = new Vector3 (
				Random.Range(-maxWidth, maxWidth), 
				transform.position.y, 
				0f
			);

			Quaternion spawnRotation = Quaternion.identity;

			Instantiate (ball, spawnPosition, spawnRotation);

			yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
		}
		yield return new WaitForSeconds (2.0f);
		gameOverText.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		restartButton.SetActive (true);
	}

	void UpdateText(){
		timerText.text = "Time Left: \n" + Mathf.RoundToInt (timeLeft);
	}

}
