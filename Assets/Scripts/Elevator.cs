using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

	[SerializeField]
	private float amplitudeX;
	[SerializeField]
	private float amplitudeY;
	[SerializeField]
	private float amplitudeZ;

	private float departX;
	private float departY;
	private float departZ;

	private float minX;
	private float minY;
	private float minZ;

	private float maxX;
	private float maxY;
	private float maxZ;

	private float posX;
	private float posY;
	private float posZ;

	private bool isXEnabled;
	private bool isYEnabled;
	private bool isZEnabled;

	private bool isXGrowing;
	private bool isYGrowing;
	private bool isZGrowing;

	void Start(){
		departX = transform.position.x;
		departY = transform.position.y;
		departZ = transform.position.z;

		isXEnabled = (amplitudeX > 0.0f);
		isYEnabled = (amplitudeY > 0.0f);
		isZEnabled = (amplitudeZ > 0.0f);

		isXGrowing = isYGrowing = isZGrowing = true;

		minX = departX - amplitudeX;
		maxX = departX + amplitudeX;

		minY = departY - amplitudeY;
		maxY = departY + amplitudeY;

		minZ = departZ - amplitudeZ;
		maxZ = departZ + amplitudeZ;
	}

	// Update is called once per frame
	void Update () {
		posX = transform.position.x;
		posY = transform.position.y;
		posZ = transform.position.z;


		if (isXEnabled) {
			if (posX <= minX || posX >= maxX)
				isXGrowing = !isXGrowing;

			if (isXGrowing)
				transform.Translate(Vector3.right * Time.deltaTime);
			else
				transform.Translate(Vector3.left * Time.deltaTime);
		}

		if (isYEnabled) {
			if (posY <= minY || posY >= maxY)
				isYGrowing = !isYGrowing;

			if (isYGrowing)
				transform.Translate(Vector3.up * Time.deltaTime);
			else
				transform.Translate(Vector3.down * Time.deltaTime);
		}

		if (isZEnabled) {
			if (posZ <= minZ || posZ >= maxZ)
				isZGrowing = !isZGrowing;

			if (isZGrowing)
				transform.Translate(Vector3.forward * Time.deltaTime);
			else
				transform.Translate(Vector3.back * Time.deltaTime);
		}
	}
}
