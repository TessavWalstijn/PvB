using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool _isPaused = false;

    public void PauseGame()
    {
        if(_isPaused)
        {
            Time.timeScale = 1;
            _isPaused = false;
        }
        else
        {
            Time.timeScale = 1;
            _isPaused = true;
        }
    }
}
