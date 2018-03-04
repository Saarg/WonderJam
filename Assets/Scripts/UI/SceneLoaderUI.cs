using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderUI : MonoBehaviour {

	public void LoadScene(string n) {
		SceneManager.LoadScene(n);
	}

	public void Quit() {
		Application.Quit(); 
	}
}
