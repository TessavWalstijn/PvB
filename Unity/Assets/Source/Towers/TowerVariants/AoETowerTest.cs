using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoETowerTest : MonoBehaviour
{
    public GameObject AoETowerImpact;

    public List<GameObject> enemiesInCollider;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Instantiate(AoETowerImpact, other.gameObject.transform.position, other.gameObject.transform.rotation);
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

    void AoETowerShoot()
    {
       
    }
}
