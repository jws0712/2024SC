using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Point;
    public GameObject child;
    public float speed;
    private void Awake()
    {
        Point = GameObject.FindGameObjectWithTag("Point");
        child = Point.transform.Find("camera pos").gameObject;
    }

    private void FixedUpdate()
    {
        follow();
    }

    private void follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position,Time.deltaTime * speed);
        gameObject.transform.LookAt(Point.gameObject.transform.position);
    }
}
