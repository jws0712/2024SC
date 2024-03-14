using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarMovement : MonoBehaviour
{

    private float vertical;
    private float horizontal;
    private bool handbrake;
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];
    public float motortorque = 200;
    public float steeringMax = 4;
    public float breakeTorque = 1000;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        input();
        AnimateWheels();
        moveVehivle();
        steerVehicle();
        breakVehicle();
    }

    void moveVehivle()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = vertical * motortorque;
        }
        

    }

    void steerVehicle()
    {
        for (int i = 0; i < wheels.Length - 2; i++)
        {
            wheels[i].steerAngle = horizontal * steeringMax;
        }
    }

    void breakVehicle()
    {
        if (handbrake)
        {
            for (int i = 2; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = breakeTorque;
            }
        }
        else
        {
            for (int i = 2; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = 0;
            }
        }

    }

    void input()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        handbrake = (Input.GetAxis("Jump") != 0) ? true : false;
    }
    void AnimateWheels()
    {
        Vector3 wheelPos = Vector3.zero;
        Quaternion wheelRot = Quaternion.identity;

        for (int i = 0; i < 4; i++)
        {
            wheels[i].GetWorldPose(out wheelPos, out wheelRot);
            wheelMesh[i].transform.position = wheelPos;
            wheelMesh[i].transform.rotation = wheelRot;
        }
    }

}
