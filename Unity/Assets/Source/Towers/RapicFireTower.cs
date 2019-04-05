using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RapidFireTower : Tower
{

    [Header("Shooting")]


       private GameObject _target;
    //private Health _enemyHealth;

    private float _targetAngle;
    private float _angleWithTarget;
    private LineRenderer _lineRenderer;
    private float _nextTickTime;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    protected override void Start()
    {
        base.Start();
        _lineRenderer.enabled = false;
        _lineRenderer.SetPosition(0, transform.position);
    }

    protected override void _OnTargetEnter()
    {
        Debug.Log("Entered");
        _target = targetsInRange[0];
       // _enemyHealth = _target.GetComponent<Health>();
    }

    protected override bool _OnTargetStay()
    {
        if (targetsInRange.Contains(_target))
        {
            _RotateToTarget();
            if (_angleWithTarget <= _minimalShootAngle)
            {
                _lineRenderer.SetPosition(1, _target.transform.position);
                _lineRenderer.enabled = true;
               _TickDamage();
            }
            return true;
        }
        return false;
    }

    protected override void _OnTargetExit()
    {
        _target = null;
        _lineRenderer.enabled = false;
    }

    private void _RotateToTarget()
    {
        // the simple, fast way of rotating
        //transform.LookAt (target.transform.position);

        // another non-physics way of rotating, interpolating the rotation
        // we need to use the function above to calucate the desired angle
        Vector3 direction = _target.transform.position - transform.position;
        _targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        _angleWithTarget = Vector3.Angle(direction, transform.forward);

        transform.rotation = Quaternion.Lerp(transform.localRotation,
            Quaternion.Euler(new Vector3(0f, _targetAngle, 0f)),
            rotationSpeed * Time.deltaTime);
    }

    private void _TickDamage()
    {
        if (Time.time >= _nextTickTime)
        {
            //_enemyHealth.TakeDamage(_damage);
            _nextTickTime = Time.time + _tickSpeed;
            print("Shoot");
        }
    }
}