using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _continueButton;

    void Start()
    {
        _continueButton.SetActive(false);
    }

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
