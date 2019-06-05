using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireBullet : MonoBehaviour
{

    /**
     * <summary>
     * Zorgt ervoor dat de kogel na 4 seconden verwijderd wordt
     * </summary>
     * <returns></returns>
     */
    void Start()
    {
       Destroy(gameObject, 4f); 
    }
}
