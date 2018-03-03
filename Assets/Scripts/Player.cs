using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	TeamNumber _team;
	public TeamNumber team { get { return _team; } set { _team = value; } }

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
	private float score = 0;
		
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
