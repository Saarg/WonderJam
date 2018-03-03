using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScript : MonoBehaviour
{

    public GameObject[] stats;
    public Image[] images;

    // Use this for initialization
    void Start ()
	{
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetStats(GameObject car)
    {
        if (car == null)
        {
            Debug.Log("car null");
            return;
        }

        float stat;
        stat = car.GetComponent<WheelVehicle>().speed;
        printStat(stats[0], images[0], stat);

        stat = car.GetComponent<WheelVehicle>().acceleration;
        printStat(stats[1], images[1], stat);

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
