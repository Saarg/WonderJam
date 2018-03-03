using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	TeamNumber _team;
	public TeamNumber team { get { return _team; } }

	[SerializeField]
	float _maxlife = 100f;
	public float maxlife { get { return _maxlife; } }
	[SerializeField]
	float _life = 100f;
	public float life { get { return _life; } }
	[SerializeField]
	private float score;

	// Use this for initialization
	void Start () {
		_maxlife = 100;
		_life = maxlife;
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
		_life += bonus;
		if (life > _maxlife)
			_life = _maxlife;
		if (life < 0)
			_life =0;

		Debug.Log ("Vie joueur : " + life);
	}
}
