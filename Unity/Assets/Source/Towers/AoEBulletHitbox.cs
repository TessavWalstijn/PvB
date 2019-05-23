using System.Collections.Generic;
using UnityEngine;

public class AoEBulletHitbox : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log(damage);

            other.GetComponent<Health>().currentHealth -= damage;
            Debug.Log(other.GetComponent<Health>().currentHealth);
            
            //List<GameObject> enemyList = transform.GetComponentInParent<_baseTower>().enemiesInCollider;
            //enemyList.Remove(other.gameObject);
        }
    }
}
