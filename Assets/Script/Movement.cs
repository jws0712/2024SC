using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float m_Speed = 10.0f; //스피드 변수
    public float m_RotateSpeed = 10.0f; //회전 변수

    public Rigidbody m_Rigid;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MyMove();
        MyRotate();

    }
    private void MyMove()
    {
        float m_movement = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * m_movement * m_Speed * Time.deltaTime;
        m_Rigid.MovePosition(m_Rigid.position + movement);
    }

    private void MyRotate()
    {
        float m_rotate = Input.GetAxis("Horizontal") * m_RotateSpeed * Time.deltaTime;
        Vector3 rotate = new Vector3(0, m_rotate, 0);
        transform.Rotate(rotate);
    }

}
