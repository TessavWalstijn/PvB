using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Integer om bij te houden hoeveel levenspunten de vijand heeft
    public int currentHealth;
    // Boolean die registreert of de vijand levend of dood is
    private bool objectIsDead = false;

    void Start()
    {
        Debug.Log(gameObject.name + " heeft: " + currentHealth + " levenspunten");
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            // De functie aanroepen wanneer de levenspunten op nul of lager komen
            RemoveGameObjectFromList();
        }
    }

    void RemoveGameObjectFromList()     // Functie die aangeeft of de vijand vernietigd kan worden
    {
        objectIsDead = true;

        Invoke("Death", 0.2f);
    }

    void Death()
    {
        Destroy(gameObject);        // Verwijderd het gameobject van de scene
    }

    void OnTriggerStay(Collider other)      // Functie om te registreren of er een object in de collider blijft
    {
        if(other.gameObject.tag == "Tower")     // Checkt of er objecten in de collider zitten met de tag: Tower
        {
            if(objectIsDead)
            {
                // Als het gameobject levenspunten heeft van 0 of lager, verwijder dit object uit de lijst van geregistreerde vijanden van de torens die de vijand gezien hebben
                other.GetComponent<_baseTower>().enemiesInCollider.Remove(gameObject);
            }
        }
    }
}
