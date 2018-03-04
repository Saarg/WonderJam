using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseControllerScript : MonoBehaviour
{
	[SerializeField]
	int def = 0;

    public string key;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt(key, def);		

		GetComponent<Dropdown>().value = def;
	}

    public void SetController(int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
}
