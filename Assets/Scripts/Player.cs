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
    public float maxBoost { get { return _maxBoost; } }
    [SerializeField]
    float _boost = 100f;
    public float boost { get { return _boost; } }

    [SerializeField]
	private float score = 0;

    public Animator animator;
		
	public void ModifyLife( float bonus){
		_life += bonus;
		if (_life > _maxlife)
        {
            _life = _maxlife;

        }else if (life < 0)
        {
            _life = 0;

        }
    }

    public void ModifyBoost(float bonus)
    {
        _boost += bonus;
        if(_boost > maxBoost)
        {
            _boost = _maxBoost;
        }else if (boost< 0)
        {
            _boost = 0;
        }
    }

	void OnCollisionEnter(Collision col) {
        /*if (col.gameObject.GetComponent<Rigidbody>() != null)
        {
            float otherMass = col.gameObject.GetComponent<Rigidbody>().mass;
            float myMass = GetComponent<Rigidbody>().mass;

            if (col.gameObject.CompareTag("Player"))
            {
                _life -= (myMass / myMass + otherMass) * col.relativeVelocity.sqrMagnitude / 200;
            }
        }*/

        if (col.gameObject.CompareTag("Player"))
        {
            _life -= col.relativeVelocity.sqrMagnitude / 20;
        }


        if (col.gameObject.CompareTag("Traps"))
        {
            _life -= col.relativeVelocity.sqrMagnitude / 100;
        }
       
    }

    void Update()
    {
        if (_life <= 0)
        {
            animator.SetTrigger("Blown");
            explosion();
            
            enabled = false;
            GetComponent<WheelVehicle>().enabled = false;
        }
    }

    private void explosion()
    {
        Transform body = transform.Find("body");
        foreach (Transform c in body)
        {
            c.gameObject.AddComponent<Rigidbody>();
            c.gameObject.AddComponent<MeshCollider>();

            c.gameObject.GetComponent<MeshCollider>().convex = true;
            c.gameObject.GetComponent<Rigidbody>().AddExplosionForce(10, transform.position - Vector3.up, 10);
        }

    }
}
