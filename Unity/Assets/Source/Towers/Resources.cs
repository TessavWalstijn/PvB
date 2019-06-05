using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public int resourceCounter;

    [SerializeField]
    private Text _resourceText;

    /**
     * <summary>
     * Voert de functie AddResources() elke 10 seconden uit
     * </summary>
     * <returns></returns>
     */
    void Start()
    {
        InvokeRepeating("AddResources" , 10f, 10f);
    }

    /**
     * <summary>
     * Zet de tekst in de UI gelijk aan de resourceCounter integer
     * </summary>
     * <returns></returns>
     */
    void Update()
    {
        _resourceText.text = resourceCounter.ToString();
    }

    /**
     * <summary>
     * Voegt resources toe aan de speler
     * </summary>
     * <returns></returns>
     */
    void AddResources()
    {
        resourceCounter += 1;
    }
}
