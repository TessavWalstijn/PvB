using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _baseTower : MonoBehaviour
{
  [Header("LookAt")]

    [SerializeField]
    private GameObject _turretHead;
    private GameObject _enemy;
   
    [SerializeField]
    private  Vector3 _startRotation;

   [Header("Bullet")]

    [SerializeField]
    protected private int _damage;
    [SerializeField]
    protected private int _fireRate;
    [SerializeField]
    protected private int _range;

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
            Shoot();
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        _enemy = null;
        _turretHead.transform.localRotation = Quaternion.Euler(_startRotation.x, _startRotation.y, _startRotation.z);
    }
    protected virtual void Shoot()
    {
       Debug.Log("firing!");
          
    }
}

