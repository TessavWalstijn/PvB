using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_LookAtEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _turretHead;

    private GameObject _enemy;
    [SerializeField] private Vector3 _startRotation;

    void Start()
    {
        _startRotation = new Vector3(_turretHead.transform.rotation.eulerAngles.x, _turretHead.transform.rotation.eulerAngles.y, _turretHead.transform.rotation.eulerAngles.z);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy spotted");
            _enemy = other.gameObject;
            _turretHead.transform.LookAt(_enemy.transform);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Enemy Left");
        _enemy = null;
        _turretHead.transform.localRotation = Quaternion.Euler(_startRotation.x, _startRotation.y, _startRotation.z);
    }
}
