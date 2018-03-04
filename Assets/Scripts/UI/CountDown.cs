using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

	[SerializeField]
	Text countText;

	float startTime;

	void Start () {
		startTime = Time.realtimeSinceStartup;

		Time.timeScale = 0;
	}
	
	void Update () {
		countText.text = Mathf.FloorToInt(5 - (Time.realtimeSinceStartup - startTime)).ToString();

		if (Time.realtimeSinceStartup - startTime >= 5f) {
			Time.timeScale = 1f;
			
			Destroy(gameObject);
		}
	}
}
