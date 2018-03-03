using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGainedDisplayer : MonoBehaviour {

    public Transform spawnTransform;
    public ScoreGainedCanvas scoreGainedCanvasPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowScoreGained(float scoreGained)
    {
        string textToShow = "+ " + (int)scoreGained;
        ScoreGainedCanvas scoreGainedCanvas = (ScoreGainedCanvas)Instantiate(scoreGainedCanvasPrefab, spawnTransform.position, spawnTransform.rotation);
        scoreGainedCanvas.transform.SetParent(spawnTransform);
        scoreGainedCanvas.GetComponentInChildren<Text>().text = textToShow;
        scoreGainedCanvas.transform.localPosition = Vector3.zero;
        scoreGainedCanvas.transform.localRotation = Quaternion.identity;
    }
}
