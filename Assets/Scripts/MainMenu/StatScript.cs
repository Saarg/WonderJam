using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScript : MonoBehaviour
{

    public GameObject[] stats;

    [SerializeField]
    public Image image;

    private int minWidht = 0;
    private int maxWidht = 350;

    private int minPos = 0;
    private int maxPos = 175;

    private int minStat = 1;
    private int maxStat = 100;

    private float yPos;
    private float zPos;

    private float yScale;
    private float zScale;

    // Use this for initialization
    void Start ()
	{
	    yPos = image.transform.position.y;
	    zPos = image.transform.position.z;
	    yScale = image.transform.localScale.y;
	    zScale = image.transform.localScale.z;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetStats(GameObject car)
    {
    }

    private void printStat(String startName)
    {
        int stat = 50;

        float curStat = (float) stat/(maxStat - minStat);

        float curPos = (maxPos - minPos) * curStat;
        float curWidth = (maxWidht - minWidht) * curStat;

        image.transform.position = new Vector3(curPos, yPos, zPos);
        image.transform.localScale = new Vector3(curWidth, yScale, zScale);

    }
}
