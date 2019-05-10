using System.Collections.Generic;
using UnityEngine;

public class AoEBulletHitbox : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            Debug.Log(damage);

            List<GameObject> enemyList = transform.GetComponentInParent<_baseTower>().enemiesInCollider;
            enemyList.Remove(other.gameObject);
        }
    }
}
