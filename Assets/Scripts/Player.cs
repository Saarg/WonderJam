using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	float _maxlife = 100f;
	public float maxlife { get { return _maxlife; } }
	[SerializeField]
	float _life = 100f;
	public float life { get { return _life; } }

    [SerializeField]
    float _maxBoost = 100f;
    public float maxBoost { get { return _maxlife; } }
    [SerializeField]
    float _boost = 100f;
    public float boost { get { return _boost; } }

    [SerializeField]
	private float score;

	// Use this for initialization
	void Start () {
		_maxlife = 100;
		_life = maxlife;
        _boost = 0;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void ModifyScore( float bonus){
		score += bonus;
		if (score < 0)
			score =0;

		Debug.Log ("Score joueur : " + score);
	}

	public void ModifyLife( float bonus){
		_life += bonus;
		if (life > _maxlife)
			_life = _maxlife;
		if (life < 0)
			_life =0;
		Debug.Log ("Vie joueur : " + life);
	}

    public void ModifyBoost(float bonus)
    {
        _boost += bonus;
        if(boost > maxBoost)
        {
            _boost = _maxBoost;
        }else if (boost< 0)
        {
            _boost = 0;
        }
    }
}
