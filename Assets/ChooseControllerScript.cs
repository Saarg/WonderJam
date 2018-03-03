using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseControllerScript : MonoBehaviour
{

    public string name;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetController(int value)
    {
        PlayerPrefs.SetInt(name, value);
    }
}
