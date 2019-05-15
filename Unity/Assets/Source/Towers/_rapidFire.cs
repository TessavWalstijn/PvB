using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _rapidFire : _baseTower
{
    [SerializeField] private GameObject _bullet;

    protected override void Shoot()
    {
        GameObject _bulletGO = Instantiate (_bullet, _firePoint.position,_firePoint.rotation);
        _bullet _Bullet = _bulletGO.GetComponent<_bullet>();
        _bulletGO.transform.parent = gameObject.transform.GetChild(0);

        _bullet bulletRef = GetComponentInChildren<_bullet>();
        bulletRef.damage = _damage;
       
        if (_bullet != null)
        {
            _Bullet.Chase(_enemy);
        }
    }
}
