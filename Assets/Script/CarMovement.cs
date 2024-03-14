using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarMovement : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];
    public float motortorque = 200;
    public float steeringMax = 4;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        AnimateWheels();
    }

    void moveVehivle()
    {

    }

    void steerVehicle()
    {

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
