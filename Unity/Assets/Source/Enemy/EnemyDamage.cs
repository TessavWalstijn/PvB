using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    private GameObject _baseObject;
    private GameObject _enemyObject;

    [SerializeField] 
    private int _damage;

    /**
     * <summary>
     * Start functie met referentie naar verschillende game objects
     * </summary>
     * <returns></returns>
     */
    void Start()
    {
        _baseObject = GameObject.Find("BaseHealth");
        _enemyObject = gameObject;
    }

    /**
     * <summary>
     * Checkt of het gameobject bij de base staat. Als het er staat herhaald de gameobject zijn damage functie elke 2 seconden
     * </summary>
     * <param name="other">other refereert naar het gameobject wat gedetecteerd wordt, wat in dit geval een gameobject met de tag 'base' is</param>
     * <returns></returns>
     */
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Base")
        {
            InvokeRepeating("DoDamage", 2f, 2f);
        }
    }

    /**
     * <summary>
     * Functie dat enemies damage laat doen als ze levenspunten hebben
     * </summary>
     * <returns></returns>
     */
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
