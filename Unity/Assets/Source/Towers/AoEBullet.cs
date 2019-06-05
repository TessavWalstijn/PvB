using UnityEngine;
using System.Collections;

public class AoEBullet : MonoBehaviour
{
    [SerializeField] private GameObject _aoeBullet;
    [SerializeField] private Transform[] _spawnLocations;
    [SerializeField] private GameObject[] hitboxHolders;

    /**
     * <summary>
     * Start de coroutines op het moment dat het object wordt ingeladen
     * </summary>
     * <returns></returns>
     */
    void Start()
    {
        StartCoroutine(StartBulletTimer());
        StartCoroutine(EnableHitbox());
    }

    /**
     * <summary>
     * Zorgt ervoor de explosie animatie op de correcte manier wordt afgespeeld
     * </summary>
     * <returns></returns>
     */
    IEnumerator StartBulletTimer()
    {
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject bullet = Instantiate(_aoeBullet, _spawnLocations[i].transform.position, transform.rotation);
            bullet.gameObject.transform.parent = gameObject.transform;

            if(i == 2)
            {
                yield return new WaitForSeconds(4f);
                Destroy(gameObject);
            }
        }
    }

    /**
     * <summary>
     * Zorgt ervoor de colliders die enemies detecteren tijdens de explosies aangezet worden
     * </summary>
     * <returns></returns>
     */
    IEnumerator EnableHitbox()
    {
        yield return new WaitForSeconds(0.5f);
        for(int i = 0; i < 3; i++)
        {
            hitboxHolders[i].GetComponent<SphereCollider>().enabled = true;

            yield return new WaitForSeconds(0.1f);

            hitboxHolders[i].GetComponent<SphereCollider>().enabled = false;

            yield return new WaitForSeconds(0.4f);
        }
    }
}
