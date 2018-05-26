using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerLoad : MonoBehaviour {
	
	void Awake () {
		SceneManager.LoadScene (1, LoadSceneMode.Additive);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			SceneManager.LoadScene (0);
		}
	}
}

