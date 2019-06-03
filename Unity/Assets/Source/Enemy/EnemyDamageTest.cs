using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageTest : MonoBehaviour
{
    [SerializeField]
    private GameObject _baseObject;

    [SerializeField]
    private GameObject _enemyObject;

    [SerializeField] 
    private int _damage;

    void Start()
    {
        _baseObject = GameObject.Find("BaseHealth");
        _enemyObject = gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Base")
        {
            InvokeRepeating("DoDamage", 2f, 2f);
        }
    }

    void DoDamage()
    {
        Debug.Log("hit");
        if(_enemyObject.GetComponent<Health>().currentHealth <= 0)
            return;

        if(_enemyObject.GetComponent<Health>().currentHealth > 0)
        {
            _baseObject.GetComponent<Health>().currentHealth -= _damage;
        }
    }
}
