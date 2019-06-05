using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _continueButton;

    /**
     * <summary>
     * Start functie die de continue image uitzet, zodat je start met een pauze image
     * </summary>
     * <returns></returns>
     */
    void Start()
    {
        _continueButton.SetActive(false);
    }

    /**
     * <summary>
     * Button functie die de timescale veranderd naar 1 en 0, wat er voor zorgt dat het spel tot een pauze komt en ook de knop veranderd van een pauze knop naar een continue knop
     * </summary>
     */
    public void PauseGame()
    {
        if(Time.timeScale == 1)
        {
            _pauseButton.SetActive(false);
            _continueButton.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            _pauseButton.SetActive(true);
            _continueButton.SetActive(false);
        }
    }
}
