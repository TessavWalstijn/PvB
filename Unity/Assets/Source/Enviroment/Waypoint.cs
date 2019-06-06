using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private GameObject _waypoints;

    // Locatie waar de vijand op loopt
    [SerializeField]
    private Transform _location;
    public Transform location { get { return _location; } }

    // Object voor visuele feedback van de waypoint
    [SerializeField]
    private Transform _visual;
}