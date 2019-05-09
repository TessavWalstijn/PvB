using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _baseTower : MonoBehaviour
{
    
  [Header("LookAt")]

    [SerializeField] private GameObject _turretHead;
    [SerializeField] private float _turnSpeed = 10f;
   
    public GameObject _enemy;
    private  Vector3 _startRotation;
    public List<GameObject> enemiesInCollider;
    private SphereCollider _collider;
    

   [Header("Bullet")]

    [SerializeField] protected private int _damage;
    [SerializeField] protected private float _fireRate;
    [SerializeField] private GameObject _bullet;
    [SerializeField] protected private Transform _firePoint;

    protected private float _fireCountdown = 0f;


    void Start() 
    {
         _collider = GetComponent<SphereCollider>();
         _rapidFire _rapidFire = new _rapidFire();
         _startRotation = new Vector3(_turretHead.transform.rotation.eulerAngles.x,
         _turretHead.transform.rotation.eulerAngles.y,
         _turretHead.transform.rotation.eulerAngles.z);
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
                if(_fireCountdown <= 0f)
                {
                    Shoot();
                    _fireCountdown = 1f / _fireRate;
                }
        _fireCountdown -= Time.deltaTime;
        }else
        {
            _enemy = null;
            Vector3.Lerp(new Vector3(_turretHead.transform.rotation.x, _turretHead.transform.rotation.y, _turretHead.transform.rotation.z), _startRotation, Time.deltaTime * _turnSpeed);
        }

        if(_enemy == null)
            return;

        Vector3 dir = _enemy.transform.position - transform.position;
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
    protected virtual void Shoot()
    {
       GameObject _bulletGO = (GameObject)Instantiate (_bullet, _firePoint.position,_firePoint.rotation);
       _bullet _Bullet = _bulletGO.GetComponent<_bullet>();


       
        if (_bullet != null)
        {
            _Bullet.Chase(_enemy);
        }
                 
    }
}

