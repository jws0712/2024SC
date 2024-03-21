using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float m_Speed = 10.0f; //스피드 변수
    public float m_RotateSpeed = 180.0f; //회전 변수
    public Rigidbody m_Rigid;

    private Transform[] m_points;
    int m_NextIdx = 1;

    private Vector3 direction;
    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        m_points = GameObject.Find("WayPoints").GetComponentsInChildren<Transform>();

        direction = m_points[m_NextIdx].position - this.transform.position;
        rotation = Quaternion.LookRotation(direction);
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, m_RotateSpeed * Time.deltaTime);
        this.transform.Translate(Vector3.forward * Time.deltaTime * m_Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WAYPOINT"))
        {
            m_NextIdx = (++m_NextIdx >= m_points.Length) ? 1 : m_NextIdx;
            direction = m_points[m_NextIdx].position - this.transform.position;
            rotation = Quaternion.LookRotation(direction);
        }
    }
}

