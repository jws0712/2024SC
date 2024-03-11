using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarMovement : MonoBehaviour
{
    public enum Axel
    {
        Frount,
        Rear
    }

    [Serializable]
    public struct wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelColl;
        public Axel axel;
    }

    public float maxAcce = 30f;
    public float breakAcce = 50f;

    public List<wheel> wheels;

    public float moveInput;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void GetInput()
    {
        moveInput = Input.GetAxis("Vertical");
    }

    void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.wheelColl.motorTorque = moveInput * 600 * maxAcce * Time.deltaTime;
        }
    }
}
