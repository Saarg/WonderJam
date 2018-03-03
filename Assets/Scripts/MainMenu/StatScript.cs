using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScript : MonoBehaviour
{

    public GameObject[] stats;
    public Image[] images;

    private int minWidht = 0;
    private int maxWidht = 350;

    private int minPos = 0;
    private int maxPos = 175;

    private int minStat = 1;
    private int maxStat = 100;

    // Use this for initialization
    void Start ()
	{
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetStats(GameObject car)
    {
        float stat;
        //stat = car.GetComponent<Player>().speed;
        printStat(stats[0], images[0], 50);

        //stat = car.GetComponent<Player>().acceleration;
        printStat(stats[1], images[1], 50);

        stat = car.GetComponent<Player>().boost;
        printStat(stats[2], images[2], stat);

        stat = 2*car.GetComponent<WheelVehicle>().steerAngle;
        printStat(stats[3], images[3], stat);

        stat = car.GetComponent<Player>().life/2;
        printStat(stats[4], images[4], stat);
    }

    private void printStat(GameObject stat, Image image, float s)
    {
        image.fillAmount = s/100.0f;
    }
}
