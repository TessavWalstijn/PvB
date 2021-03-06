﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlot : MonoBehaviour
{
    // Referenties naar de UI menu's die boven de plot weergegeven worden
    [Header("Radial Menus")]
    [SerializeField] private GameObject _radialMenu;
    [SerializeField] private GameObject _builtTowerRadialMenu;

    // Boolean om bij te houden of er wel of niet gebouwd is op een plot
    public bool plotHasBuilding = false;

    /**
     * <summary>
     * Start functie dat de menu's uitzet wanneer de game start
     * </summary>
     * <returns></returns>
     */
    void Start()
    {
        // Zet de UI menu's uit als de game wordt opgestart
        _radialMenu.SetActive(false);
        _builtTowerRadialMenu.SetActive(false);
    }

    /**
     * <summary>
     * Functie om de plot aan te zetten als een plot geselecteerd wordt
     * </summary>
     */
    public void EnablePlot()        
    {
        if(!plotHasBuilding)
            _radialMenu.SetActive(true);
        
        else
            _builtTowerRadialMenu.SetActive(true);
    }

    /**
     * <summary>
     * Functie om de plot uit te zetten als een plot gedeselecteerd wordt
     * </summary>
     */
    public void DisablePlot()       
    {
        if(!plotHasBuilding)
            _radialMenu.SetActive(false);

        else
            _builtTowerRadialMenu.SetActive(false);
    }
}
