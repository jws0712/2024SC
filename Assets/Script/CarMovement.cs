using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarMovement : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];
    public float torque = 200;
    public float steeringMax = 4;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        AnimateWheels();

        if (Input.GetKey(KeyCode.W))
        {
            for(int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = torque;
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = 0;
            }
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].steerAngle = Input.GetAxis("Horizontal") * steeringMax;
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].steerAngle = 0;
            }
        }

        void AnimateWheels()
        {
            Vector3 wheelPos = Vector3.zero;
            Quaternion wheelRot = Quaternion.identity;

            for(int i = 0; i < 4; i++)
            {
                wheels[i].GetWorldPose(out wheelPos, out wheelRot);
                wheelMesh[i].transform.position = wheelPos;
                wheelMesh[i].transform.rotation = wheelRot;
            }
        }
    }
}
