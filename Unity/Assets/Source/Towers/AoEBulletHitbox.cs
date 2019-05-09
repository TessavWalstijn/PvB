using UnityEngine;

public class AoEBulletHitbox : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
