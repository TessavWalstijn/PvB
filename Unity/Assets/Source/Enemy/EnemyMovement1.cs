using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    [SerializeField]
    private GameObject _waypoints;

    [SerializeField]
    private float _speed = 5;
    private VisualConnections _visual;
    private Transform[] _targets;
    private bool _move = false;
    private int _location = 1;

    public bool move { get { return _move; } }
    
    // public void Start()
    // {
    //     // _visual = _waypoints.GetComponent<VisualConnections>();
    // }

    void Start ()
    {
        _SetUp();
    }

    void _SetUp()
    {
        _targets = _waypoints.GetComponent<Waypoints>().GetEnemyRoad((int)Random.Range(0, 3));
        transform.position = _targets[0].position;
        _move = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_move) return;

        float step = _speed * Time.deltaTime; // calculate distance to move
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