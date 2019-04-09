using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField]
    private int _id;

    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private GameObject _waypoints;

    [SerializeField]
    private Transform _location;
    private EnemyMovement _scriptEnemy;
    private Waypoints _scriptWaypoints;
    private VisualConnections _scriptVisual;


    void Start()
    {
        _scriptEnemy = _enemy.GetComponent<EnemyMovement>();
        _scriptWaypoints = _waypoints.GetComponent<Waypoints>();
        _scriptVisual = _waypoints.GetComponent<VisualConnections>();
    }

    void OnMouseDown()
    {
        if (_scriptEnemy.move) return;

        int[] connections = _scriptWaypoints.GetAvailbleEnemyConnections(_scriptEnemy.location);
        int max = connections.Length;
        for (int i = 1; i < max; i += 1)
        {
            print(_id + " " + connections[i]);
            if (_id == connections[i])
            {
                print("test");
                _scriptVisual.ShowMove(_id);
                _scriptEnemy.Move(_location, _id);
            }
        }
    }
}