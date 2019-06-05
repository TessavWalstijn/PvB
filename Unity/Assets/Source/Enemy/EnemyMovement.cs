using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2;
    public float speed {
        set {
            if (value > 0 && value < 5) {
                _speed = value;
            }
        }
    }
    private Transform[] _targets;
    private int _location = 1;
    private bool _move = false;

    private string _side = "left";

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    /**
     * <summary>
     * Moves the enemy to the next point of the road.
     * </summary>
     */
    private void _Move ()
    {
        if (!_move) return;

        float step = _speed * Time.deltaTime * 0.01f; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, _targets[_location].position, step);
        transform.LookAt(_targets[_location]);
        // Vector3 direction = transform.position - _targets[_location].position;
        // Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
        // transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, _speed * Time.time);

        // Vector3.Lerp()

        if (Vector3.Distance(transform.position, _targets[_location].position) < 0.000001f)
        {
            _location += 1;

            if (_location >= _targets.Length) {
                _location = 1;
                _move = false;
            }
        }
    }

    /**
     * <summary>
     * Setup gives the enemy promission to walk the given road.
     * </summary>
     * <param name="targets">give the transform array of the road</param>
     */
    public void SetUp(Transform[] targets)
    {
        _targets = targets;
        _move = true;
    }
}