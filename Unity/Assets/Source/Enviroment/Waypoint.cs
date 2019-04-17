using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField]
    private int _id;
    public int id { get { return _id; } }

    [SerializeField]
    private GameObject _waypoints;

    [SerializeField]
    private Transform _location;
    public Transform location { get { return _location; } }

    [SerializeField]
    private Transform _visual;
    private EnemyMovement _scriptEnemy;
    private Waypoints _scriptWaypoints;
    private VisualConnections _scriptVisual;


    void Start ()
    {
        // _scriptEnemy = _enemy.GetComponent<EnemyMovement>();
        // _scriptWaypoints = _waypoints.GetComponent<Waypoints>();
        // _scriptVisual = _waypoints.GetComponent<VisualConnections>();
    }

    // void OnMouseDown()
    // {
    //     int[] connections = _scriptWaypoints.GetAvailbleEnemyConnections(0);
    //     int max = connections.Length;
    //     for (int i = 1; i < max; i += 1)
    //     {
    //         if (_id == connections[i])
    //         {
    //             _scriptVisual.ShowMove(_id);
    //             // _scriptEnemy.Move(_location, _id);
    //         }
    //     }
    // }
}