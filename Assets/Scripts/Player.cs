using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private float maxlife;
	[SerializeField]
	private float life;
	[SerializeField]
	private float score;

	// Use this for initialization
	void Start () {
		maxlife = 100;
		life = maxlife;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void modifyScore( float bonus){
		score += bonus;
		if (score < 0)
			score =0;

		Debug.Log ("Score joueur : " + score);
	}

	public void modifyLife( float bonus){
		life += bonus;
		if (life > maxlife)
			life = maxlife;
		if (life < 0)
			life =0;

		Debug.Log ("Vie joueur : " + life);
	}
}
