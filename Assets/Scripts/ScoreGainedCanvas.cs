using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGainedCanvas : MonoBehaviour {

    [Range(0,5)]
    public float distForFading = 1f;
    [Range(0, 2)]
    public float timeForFading = 1f;
    private float currentTime = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (currentTime < timeForFading)
        {
            currentTime += Time.deltaTime;
            float currentDist = Mathf.Lerp(0, distForFading, currentTime);
            transform.localPosition = new Vector3(0, currentDist, 0);
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
