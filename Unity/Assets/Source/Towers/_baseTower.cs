﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _baseTower : MonoBehaviour
{   
  [Header("LookAt")]

    [SerializeField] private GameObject _turretHead;
    [SerializeField] private float _turnSpeed = 10f;
   
    public GameObject _enemy;
    public List<GameObject> enemiesInCollider;
    private SphereCollider _collider;
    

   [Header("Bullet")]

    [SerializeField] protected private int _damage;
    [SerializeField] protected private float _fireRate;
    [SerializeField] protected private Transform _firePoint;

    protected private float _fireCountdown = 0f;

    void Start() 
    {
         _collider = GetComponent<SphereCollider>();
         //_rapidFire _rapidFire = new _rapidFire();
    }

    void Update()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemiesInCollider)
        {
            float _distanceToNearestEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(_distanceToNearestEnemy < shortestDistance)
            {
                shortestDistance = _distanceToNearestEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= _collider.radius)
        {
            _enemy = nearestEnemy.gameObject;
        }else
        {
            _enemy = null;
        }

        if(_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }

        _fireCountdown -= Time.deltaTime;

        if(_enemy == null)
        {
            return;
        }

        Vector3 dir = _enemy.transform.position - _turretHead.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Quaternion rotation = Quaternion.Lerp(_turretHead.transform.rotation, lookRotation, Time.deltaTime * _turnSpeed); 
    }
      
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemiesInCollider.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            enemiesInCollider.Remove(other.gameObject);
        }
    }

    protected virtual void Shoot()
    {
                 
    }
}

