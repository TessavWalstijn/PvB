using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlot : MonoBehaviour
{
    [Header("Radial Menus")]
    [SerializeField] private GameObject _radialMenu;
    [SerializeField] private GameObject _builtTowerRadialMenu;

    public bool _plotHasBuilding = false;

    void Start()
    {
        _radialMenu.SetActive(false);
        _builtTowerRadialMenu.SetActive(false);
    }

    public void EnablePlot()
    {
        if(!_plotHasBuilding)
            _radialMenu.SetActive(true);
        
        else
            _builtTowerRadialMenu.SetActive(true);
    }

    public void DisablePlot()
    {
        if(!_plotHasBuilding)
            _radialMenu.SetActive(false);

        else
            _builtTowerRadialMenu.SetActive(false);
    }
}
