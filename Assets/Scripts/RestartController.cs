using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour {

	public void RestartGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
