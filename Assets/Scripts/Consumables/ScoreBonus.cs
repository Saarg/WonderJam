using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBonus : MonoBehaviour {

	[SerializeField]
	private float value;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			Player p = other.GetComponent<Player> ();
			p.ModifyScore (value);
		}

	}
}
