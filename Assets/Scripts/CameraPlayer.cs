using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour {

    private WheelVehicle wheelVehicle;
    private Transform cameraTransform;
    private Vector3 baseCameraPosition;
    private Vector3 baseAttachPointRotation;

    [Header("Speed depth")]
    public bool useSpeedDepth = true;
    [Range(0, 10)]
    public float MaxDistance = 1;
    public float CurrentDistance;
    [Range(0, 100)]
    public float maxSpeed;

    [Header("Speed depth")]
    public bool useCameraRotationControl = true;
    public string inputName = "RHorizontal";
    [Range(0, 90)]
    public float maxAngle = 45;

    // Use this for initialization
    void Start () {
        wheelVehicle = GetComponentInParent<WheelVehicle>();
        cameraTransform = GetComponentInChildren<Camera>().transform;
        baseCameraPosition = cameraTransform.localPosition;
        baseAttachPointRotation = transform.localEulerAngles;
    }
	
	// Update is called once per frame
	void Update () {

        if (useSpeedDepth)
        {
            CurrentDistance = MaxDistance * (wheelVehicle.speed / maxSpeed);
            cameraTransform.localPosition = baseCameraPosition - new Vector3(0, 0, CurrentDistance);
        }

        if (useCameraRotationControl)
        {
            float input = MultiOSControls.GetValue(inputName, PlayerNumber.All);
            Vector3 rotation = baseAttachPointRotation + new Vector3(0, input * maxAngle, 0);
            transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        }

       
    }
}
