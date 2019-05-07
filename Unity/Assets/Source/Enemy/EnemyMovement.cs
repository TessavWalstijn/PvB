using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _waypoints;

    [SerializeField]
    private float _speed = 5;
    private Transform[] _targets;
    private bool _move = false;
    private int _location = 1;

    private string _side = "left";

    public bool move { get { return _move; } }
    
    // public void Start()
    // {
    //     // _visual = _waypoints.GetComponent<VisualConnections>();
    // }

    void Start ()
    {
        _waypoints = GameObject.Find("Paths");
        _SetUp();
    }

    void _SetUp()
    {
        if (_side == "left") {
            _targets = _waypoints.GetComponent<Waypoints>().GetEnemyRoad((int)Random.Range(0, 3), "left");
            _side = "right";
        } else { 
            _targets = _waypoints.GetComponent<Waypoints>().GetEnemyRoad((int)Random.Range(0, 3), "right");
            _side = "left";
        }

        transform.position = _targets[0].position;
        _move = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_move) return;

        float step = _speed * Time.deltaTime * 0.01f; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, _targets[_location].position, step);
        transform.LookAt(_targets[_location]);

        if (Vector3.Distance(transform.position, _targets[_location].position) < 0.000001f)
        {
            _location += 1;

            if (_location >= _targets.Length) {
                _location = 1;
                _move = false;
                _SetUp();
            }
        }
    }
}