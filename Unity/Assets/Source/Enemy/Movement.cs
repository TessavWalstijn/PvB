using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _waypoints;
    private VisualConnections _visual;
    private int _location = 0;
    public int location { get { return _location; } }
    private bool _move = false;
    public bool move { get { return _move; } }
    private Transform _target;
    
    public void Start()
    {
        _visual = _waypoints.GetComponent<VisualConnections>();
    }

    public void Move(Transform target, int id)
    {
        if (_move) return;

        _target = target;
        _location = id;
        _move = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (_move)
        {
            float step = 5 * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
            transform.LookAt(_target);

            if (Vector3.Distance(transform.position, _target.position) < 0.001f)
            {
                if (_move) {
                    _move = false;
                    transform.rotation = Quaternion.identity;
                    _visual.ShowAvailbleConnections(_location);
                }
            }
            
        }
        
    }
    
}