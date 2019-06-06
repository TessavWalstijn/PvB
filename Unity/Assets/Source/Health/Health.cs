using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Integer om bij te houden hoeveel levenspunten de vijand heeft
    public int currentHealth;
    // Boolean die registreert of de vijand levend of dood is
    private bool _objectIsDead = false;

    /**
     * <summary>
     * Update functie die bijhoudt wanneer de levenspunten op 0 komen.
     * </summary>
     * <returns></returns>
     */
    void Update()
    {
        if(currentHealth <= 0)
        {
            // De functie aanroepen wanneer de levenspunten op nul of lager komen
            RemoveGameObjectFromList();
        }
    }

    /**
     * <summary>
     * Functie die aangeeft of de vijand vernietigd kan worden
     * </summary>
     * <returns></returns>
     */
    void RemoveGameObjectFromList()
    {
        _objectIsDead = true;

        Invoke("Death", 0.2f);
    }

    /**
     * <summary>
     * Verwijderd het gameobject van de scene
     * </summary>
     * <returns></returns>
     */
    void Death()
    {
        Destroy(gameObject);        
    }

    /**
     * <summary>
     * Functie om te registreren of er een object in de collider blijft
     * </summary>
     * <param name="other">other is hier het gameobject wat botsts met de collider van dit gameobject en een tag heeft met 'Tower'</param>
     * <returns></returns>
     */
    void OnTriggerStay(Collider other)      
    {
        if(other.gameObject.tag == "Tower")     // Checkt of er objecten in de collider zitten met de tag: Tower
        {
            if(_objectIsDead)
            {
                // Als het gameobject levenspunten heeft van 0 of lager, verwijder dit object uit de lijst van geregistreerde vijanden van de torens die de vijand gezien hebben
                other.GetComponent<BaseTower>().enemiesInCollider.Remove(gameObject);
            }
        }
    }
}
