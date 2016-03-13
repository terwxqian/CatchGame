using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
	public int ballValue;

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		score += ballValue;
		UpdateScore ();
	} 

	void UpdateScore () {
		scoreText.text = "Score:\n" + score;
	}
}
