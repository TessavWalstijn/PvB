using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : BaseTower
{
    [SerializeField] private GameObject _bullet;

    protected override void Shoot()
    {
        GameObject _bulletGO = Instantiate (_bullet, _firePoint.position,_firePoint.rotation);
        Bullet _Bullet = _bulletGO.GetComponent<Bullet>();
        _bulletGO.transform.parent = gameObject.transform.GetChild(0);

        Bullet bulletRef = GetComponentInChildren<Bullet>();
        bulletRef.damage = _damage;
       
        if (_bullet != null)
        {
            _Bullet.Chase(_enemy);
        }
    }
}
