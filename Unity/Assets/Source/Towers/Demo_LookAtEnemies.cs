using UnityEngine;
using System.Collections.Generic;

public class Demo_LookAtEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _turretHead;
    [SerializeField] private GameObject _target;

    [SerializeField] private float _turnSpeed = 10f;

    private SphereCollider _collider;
    private Vector3 _startRotation;

    public List<GameObject> enemiesInCollider;

    void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _startRotation = new Vector3(0,90,0);
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
            _target = nearestEnemy.gameObject;
        }else
        {
            _target = null;
        }

        if(_target == null)
            return;

        Vector3 dir = _target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Quaternion rotation = Quaternion.Lerp(_turretHead.transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
        _turretHead.transform.rotation = rotation;
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
}
