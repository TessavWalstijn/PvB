using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPauseButton : MonoBehaviour
{
    private bool _pause;

    public void Pause()
    {
        if(_pause)
        {
            Time.timeScale = 1;
            _pause = false;
        }
        else
        {
            Time.timeScale = 0;
            _pause = true;
        }
    }
}
