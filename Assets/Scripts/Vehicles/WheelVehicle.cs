﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//

[RequireComponent(typeof(Rigidbody))]
public class WheelVehicle : MonoBehaviour {

    [Header("Inputs")]
    public PlayerNumber playerNumber = PlayerNumber.Player1;
	public string throttleInput = "Throttle";
    public string brakeInput = "Brake";
    public string turnInput = "Horizontal";
    public string boostInput = "Boost";
    public string jumpInput = "Jump";
    public string resetInput = "Reset";

    [Header("Wheels")]
    public WheelCollider[] driveWheel;
    public WheelCollider[] turnWheel;

    [Header("Behaviour")]
    // Engine
    public AnimationCurve motorTorque;
    public float brakeForce = 1500.0f;
    [Range(0f, 50.0f)]
    public float steerAngle = 30.0f;
    [Range(0.001f, 10.0f)]
    public float steerSpeed = 0.2f;
    // Boost
    [Range(1f, 50f)]
    public float boostPowerTweaker = 15f;
    [Range(0f, 50f)]
    public float boostConsumptionTweaker = 20f;
    //Jump
    float lastJump = 0;
    [SerializeField]
    float jumpCD = 1f;
    [SerializeField]
    float jumpMult = 5f;
    [Range(0.2f, 2f)]   
    public float jumpSuspensionMagnitude = 1f;
    private float baseSuspensionMagnitude = .2f;
    //Reset
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    public Transform centerOfMass;

    [Header("External inputs")]
    public float steering = 0.0f;
    public float throttle { get; set; }

    public bool handbreak = false;

    public float speed = 0.0f;

    [Header("Particles")]
    public ParticleSystem gasParticle;
    public ParticleSystem boostParticle;

    private Rigidbody _rb;
    private Player player;

    [Header("ForUI only")]
    [Range(0f, 200f)]
    public float acceleration = 100f;
    [Range(0f, 200f)]    
    public float topSpeed = 100f;

    public float scale;

    void Start ()
    {
        _rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;

        if (centerOfMass)
        {
            _rb.centerOfMass = centerOfMass.localPosition;
        }
    }
	
	void FixedUpdate () {
        speed = transform.InverseTransformDirection(_rb.velocity).z * 3.6f;

        // Accelerate & brake
        if (throttleInput != "" && throttleInput != null)
        {
            // throttle = Input.GetAxis(throttleInput) != 0 ? Input.GetAxis(throttleInput) : Mathf.Clamp(throttle, -1, 1);
			throttle = MultiOSControls.GetValue(throttleInput, playerNumber) - MultiOSControls.GetValue(brakeInput, playerNumber); 
        }

        // Turn
        foreach (WheelCollider wheel in turnWheel)
        {
			wheel.steerAngle = Mathf.Lerp(wheel.steerAngle, MultiOSControls.GetValue(turnInput, playerNumber) * steerAngle, steerSpeed);
        }

        // Boost
        if(MultiOSControls.GetValue(boostInput, playerNumber) > .5f && player.boost > 0 )
        {
            float deltaTime = Time.deltaTime;
            _rb.AddForce(transform.forward * _rb.mass * boostPowerTweaker);
            boostParticle.Emit((int)Mathf.Lerp(0, boostParticle.emission.rateOverTime.constantMax, deltaTime) );
            player.ModifyBoost(-boostConsumptionTweaker * deltaTime);
        }
        else
        {
            boostParticle.Stop();
        }
        
        // Jump
        if (MultiOSControls.GetValue(jumpInput, playerNumber) > .5f && Time.realtimeSinceStartup - lastJump > jumpCD && driveWheel[0].suspensionDistance == baseSuspensionMagnitude)
        {
            lastJump = Time.realtimeSinceStartup;

            _rb.AddForce(transform.forward * _rb.mass * jumpMult + transform.up * _rb.mass * 2 *jumpMult, ForceMode.Impulse);
        }

        if (MultiOSControls.GetValue(jumpInput, playerNumber) > .5f) {
            foreach(WheelCollider wheelCollider in driveWheel)
            {
                wheelCollider.suspensionDistance = jumpSuspensionMagnitude;
            }
            foreach (WheelCollider wheelCollider in turnWheel)
            {
                wheelCollider.suspensionDistance = jumpSuspensionMagnitude;
            }
        }
        else
        {
            foreach (WheelCollider wheelCollider in driveWheel)
            {
                wheelCollider.suspensionDistance = baseSuspensionMagnitude;
            }
            foreach (WheelCollider wheelCollider in turnWheel)
            {
                wheelCollider.suspensionDistance = baseSuspensionMagnitude;
            }
        }

        // Reset
        if (MultiOSControls.GetValue(resetInput, playerNumber) > .5f)
        {
            transform.position = spawnPosition;
            transform.rotation = spawnRotation;
        }


        foreach (WheelCollider wheel in GetComponentsInChildren<WheelCollider>())
        {
            wheel.brakeTorque = 0;
        }

        if (handbreak)
        {
            foreach (WheelCollider wheel in GetComponentsInChildren<WheelCollider>())
            {
                wheel.motorTorque = 0;
                wheel.brakeTorque = brakeForce;
            }
        }
        else if (Mathf.Abs(speed) < 4 || Mathf.Sign(speed) == Mathf.Sign(throttle))
        {
            foreach (WheelCollider wheel in driveWheel)
            {
                wheel.brakeTorque = 0;
                wheel.motorTorque = throttle * motorTorque.Evaluate(speed) * 4;
            }
        }
        else
        {
            foreach (WheelCollider wheel in GetComponentsInChildren<WheelCollider>())
            {
                wheel.motorTorque = 0;
                wheel.brakeTorque = Mathf.Abs(throttle) * brakeForce;
            }
        }


        _rb.AddForce(- _rb.mass * transform.forward * speed/5 );

        if(gasParticle)
        {
            ParticleSystem.EmissionModule em = gasParticle.emission;
            em.rateOverTime = handbreak ? 0 : Mathf.Lerp(em.rateOverTime.constant, Mathf.Clamp(10.0f * throttle, 5.0f, 10.0f), 0.1f);
        }
	}

    public void toogleHandbrake(bool h)
    {
        handbreak = h;
    }
}
