using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private GameObject _waypoints;

    // Location for the enemy to walk to.
    [SerializeField]
    private Transform _location;
    public Transform location { get { return _location; } }

    // For the user a visual object.
    [SerializeField]
    private Transform _visual;
}