using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseControllerScript : MonoBehaviour
{

    public string key;

    public int defaultChoose;

	// Use this for initialization
	void Start () {
	    PlayerPrefs.SetInt(name, defaultChoose);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetController(int value)
    {
        PlayerPrefs.SetInt(name, value);
    }
}
