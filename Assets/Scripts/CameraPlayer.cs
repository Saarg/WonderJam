using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour {

    private WheelVehicle wheelVehicle;
    private Vector3 baseLocalPosition;

    [Range(0, 10)]
    public float MaxDistance = 1;
    public float CurrentDistance;

    [Range(0, 100)]
    public float maxSpeed;

	// Use this for initialization
	void Start () {
        wheelVehicle = GetComponentInParent<WheelVehicle>();
        baseLocalPosition = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {

        CurrentDistance = MaxDistance * (wheelVehicle.speed / maxSpeed);

        transform.localPosition = baseLocalPosition - new Vector3(0, 0, CurrentDistance);
    }
}
