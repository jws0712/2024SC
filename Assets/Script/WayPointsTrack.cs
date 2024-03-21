using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsTrack : MonoBehaviour
{
    public Color lineColor = Color.white;
    private Transform[] _points;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnDrawGizmos()
    {
        _points = GetComponentsInChildren<Transform>();
        int nextIdx = 1;

        Vector3 CurrentPoint = _points[nextIdx].position;
        Vector3 NextPoint;

        for (int i = 0; i <= _points.Length; i++)
        {
            NextPoint = (++nextIdx >= _points.Length) ? _points[1].position : _points[nextIdx].position;
            Gizmos.color = lineColor;
            Gizmos.DrawLine(CurrentPoint, NextPoint);

            CurrentPoint = NextPoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
