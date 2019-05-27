using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tower Variables")]
    [Tooltip("Reference to the head of the tower gameobject that points towards the enemy")]
    [SerializeField] private GameObject _towerHead;

    [Tooltip("Float which defines the speed of the rotating part")]
    [SerializeField] private float _turnSpeed;

    [Tooltip("Float which defines the rate of fire that the turret shoots at")]
    [SerializeField] private float _fireRate;

    [Space]

    [Header("Bullet Variables")]
    [Tooltip("Reference to the bullet prefab")]
    [SerializeField] private GameObject _bulletObject;

    [Tooltip("Reference to the point where the bullet shoots from")]
    [SerializeField] private Transform _bulletFirePoint;

    [Space]

    [Header("Enemies Reference for Debugging")]
    [Tooltip("Reference to the current enemy targeted")]
    public GameObject enemyObject;

    [Tooltip("List of enemies who are currently in range of the tower")]
    public List<GameObject> enemiesInCollider;

    private float _fireCountdown = 0f;
    private SphereCollider _towerCollider;

    void Start()
    {
        _towerCollider = GetComponent<SphereCollider>();
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

        if(nearestEnemy != null && shortestDistance <= _towerCollider.radius)
        {
            enemyObject = nearestEnemy.gameObject;
        }else
        {
            enemyObject = null;
        }

        if(_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }

        _fireCountdown -= Time.deltaTime;

        if(enemyObject == null)
        {
            return;
        }

        Vector3 dir = enemyObject.transform.position - _towerHead.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Quaternion rotation = Quaternion.Lerp(_towerHead.transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
        _towerHead.transform.rotation = rotation;
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
