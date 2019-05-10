using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public bool objectIsDead = false;

    void Update()
    {
        if(currentHealth <= 0)
        {
            RemoveGameObjectFromList();
        }
    }

    void RemoveGameObjectFromList()
    {
        objectIsDead = true;

        Invoke("Death", 0.2f);
    }

    void Death()
    {
        Destroy(gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Tower")
        {
            Debug.Log("Enemy staat in range van: " + other.gameObject.name);
            if(objectIsDead)
            {
                Debug.Log(other.GetComponent<_baseTower>().enemiesInCollider.Count);
                other.GetComponent<_baseTower>().enemiesInCollider.Remove(gameObject);
            }
        }
    }
}
