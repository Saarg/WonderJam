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
		countText.transform.localScale = Vector3.one * (0.5f * (Time.realtimeSinceStartup - startTime)%1);

		if (Time.realtimeSinceStartup - startTime >= 4f) {
			Time.timeScale = 1f;
			
			Destroy(gameObject);
		}
	}
}
