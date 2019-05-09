using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _baseTower : MonoBehaviour
{
    
  [Header("LookAt")]

    [SerializeField]
    private GameObject _turretHead;
    public static GameObject _enemy;
   
    [SerializeField]
    private  Vector3 _startRotation;

   [Header("Bullet")]

    [SerializeField]
    protected private int _damage;
    [SerializeField]
    protected private float _fireRate;
    
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    protected private Transform _firePoint;
    protected private float _fireCountdown = 0f;
    void Start() 
    {
         _rapidFire _rapidFire = new _rapidFire();
         _startRotation = new Vector3(_turretHead.transform.rotation.eulerAngles.x,
         _turretHead.transform.rotation.eulerAngles.y,
         _turretHead.transform.rotation.eulerAngles.z);
    }
      
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            _enemy = other.gameObject;
            _turretHead.transform.LookAt(_enemy.transform);
            if(_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = 1f / _fireRate;
            }
        }
        _fireCountdown -= Time.deltaTime;
    }

    void OnTriggerExit(Collider other)
    {
        _enemy = null;
        _turretHead.transform.localRotation = Quaternion.Euler(_startRotation.x, _startRotation.y, _startRotation.z);
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

