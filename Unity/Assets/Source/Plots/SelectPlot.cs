using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlot : MonoBehaviour
{
    [SerializeField] private GameObject _radialMenu;

    void Start()
    {
        _radialMenu.SetActive(false);
    }

    public void EnablePlot()
    {
        _radialMenu.SetActive(true);
    }

    public void DisablePlot()
    {
        _radialMenu.SetActive(false);
    }
}
