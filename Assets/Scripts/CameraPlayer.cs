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

    [Header("Camera Rotation")]
    public bool useCameraRotationControl = true;
    public string inputName = "RHorizontal";
    [Range(0, 90)]
    public float maxAngle = 45;
    [Range(1f, 10)]
    public float cameraRotationSpeed = 5f;

    [Header("Camera fix")]
    public bool useCameraFix = true;
    [Range(0, 2)]
    public float minHeight = 1f;

    private Transform target;

    // Use this for initialization
    void Start () {
        wheelVehicle = GetComponentInParent<WheelVehicle>();
        cameraTransform = GetComponentInChildren<Camera>().transform;
        baseCameraPosition = cameraTransform.localPosition;
        baseAttachPointRotation = transform.localEulerAngles;

        target = transform.parent;
        transform.SetParent(transform.parent.parent);
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (useSpeedDepth)
        {
            CurrentDistance = MaxDistance * (wheelVehicle.speed / maxSpeed);
            cameraTransform.localPosition = baseCameraPosition - new Vector3(0, 0, CurrentDistance);
        }

        if (useCameraRotationControl)
        {
            float input = MultiOSControls.GetValue(inputName, wheelVehicle.playerNumber);
            Vector3 rotation = baseAttachPointRotation + new Vector3(0, input * maxAngle, 0);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotation.x, rotation.y, rotation.z), cameraRotationSpeed * Time.deltaTime);
        }
        if (useCameraFix && cameraTransform.position.y < minHeight)
        {
            cameraTransform.position = new Vector3(cameraTransform.position.x, minHeight, cameraTransform.position.y);
        }*/
    }

    void LateUpdate() {
        if (useSpeedDepth)
        {
            CurrentDistance = MaxDistance * (wheelVehicle.speed / maxSpeed);
        }
        
        float input = 0;
        if (useCameraRotationControl)
        {
            input = MultiOSControls.GetValue(inputName, wheelVehicle.playerNumber);           
        }

        transform.LookAt(target.position + input * target.right);
        transform.position = Vector3.Lerp(transform.position, target.position - target.forward * (5+CurrentDistance) + target.up * 1, Time.deltaTime * 3);
    }
}
