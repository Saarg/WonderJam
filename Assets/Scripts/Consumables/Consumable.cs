using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour {

	[SerializeField]
	private int nbUses;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			nbUses--;
			if (nbUses >= 0)
				Destroy (gameObject,0);
		}

	}
}
