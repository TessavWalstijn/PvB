using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    [SerializeField]
    private Transform _startpoint;
    [SerializeField]
    private Transform[] _waypoints;

    [SerializeField]
    private bool _drawPath;

    public Transform[] GetWaypoints()
    {
        return _waypoints;
    }

    private void OnDrawGizmos()
    {
        if (_drawPath)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(_startpoint.position, _waypoints[0].position);
            for (int i = 1; i < _waypoints.Length; i++)
            {
                Gizmos.DrawLine(_waypoints[i].position, _waypoints[i - 1].position);
            }
        }
    }
}
