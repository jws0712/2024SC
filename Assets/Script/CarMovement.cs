using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarMovement : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelMesh;
        public WheelCollider wheelCollider;
        public GameObject wheelEffectObj;
        public ParticleSystem Smoke;
        public Axel axel;
    }

    public float maxAccel = 30.0f;
    public float breakAccel = 50.0f;

    public float turnSens = 1.0f;
    public float maxStearAngle = 30.0f;

    public Vector3 _centerofMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = _centerofMass;
    }

    private void Update()
    {
        CarInputs();
        AnimationWheels();
        WheelEffects();
    }

    private void LateUpdate()
    {
        Move();
        Stear();
        Break();
    }

    void CarInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * 600 * maxAccel * Time.deltaTime;
        }
    }

    void Stear()
    {
        foreach(var wheel in wheels)
        {
            if(wheel.axel == Axel.Front)
            {
                var _stearAngle = steerInput * turnSens * maxStearAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _stearAngle, 0.6f);
            }
        }
    }

    void Break()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach(var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * breakAccel * Time.deltaTime;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    void AnimationWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelMesh.transform.position = pos;
            wheel.wheelMesh.transform.rotation = rot;
        }
    }

    void WheelEffects()
    {
        foreach(var wheel in wheels)
        {
            if (Input.GetKey(KeyCode.Space) && wheel.axel == Axel.Rear)
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = true;
                wheel.Smoke.Emit(1);
            }
            else
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;
            }
        }
    }
}   
