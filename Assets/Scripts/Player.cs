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
		
	public void modifyScore( float bonus){
		score += bonus;
		if (score < 0)
			score =0;
	}

	public void modifyLife( float bonus){
		life += bonus;
		if (life > maxlife)
			life = maxlife;
		if (life < 0)
			life =0;
	}
}
