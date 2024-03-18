using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    public float turnSpeed = 180;
    public float turnV;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveVer();
        Rotate();
    }

    private void MoveVer()
    {
        float movement = Input.GetAxis("Vertical");
        Vector3 move = transform.right * movement * Speed * Time.deltaTime;
        rb.MovePosition(rb.position + move);
    }

    private void Rotate()
    {
        float turnvalue = Input.GetAxis("Horizontal");
        float turn = turnV * turnSpeed * Time.deltaTime;
        Quaternion turnRot = Quaternion.Euler(0f, turn, 0);
        rb.MoveRotation(turnRot);
    }
}
