using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGainedDisplayer : MonoBehaviour {

    public Transform spawnTransform;
    public ScoreGainedCanvas scoreGainedCanvasPrefab;

    [Header("Sounds")]
    public AudioSource AudioSource;
    public AudioClip[] ExplosionClips;


    // Use this for initialization
    void Start () {
        if (AudioSource == null) { }
            // TODO
		
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
        playSoundOnCollision();
    }

    private void playSoundOnCollision()
    {
        int sound = Random.Range(0, ExplosionClips.Length);
        AudioSource.PlayOneShot(ExplosionClips[sound], 1);

    }
}
