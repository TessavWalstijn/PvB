using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private bool _gameStarted;

    [SerializeField]
    private GameObject _enemySpawn;

    [SerializeField]
    private GameObject _startButton;

    [SerializeField]
    private GameObject _resourceIndicator;

    /**
     * <summary>
     * Start functie die bepaalde dingen uitzet voordat het spel start
     * </summary>
     * <returns></returns>
     */
    void Start()
    {
        _gameStarted = false;
        _resourceIndicator.SetActive(false);
        _enemySpawn.SetActive(false);
    }

    /**
     * <summary>
     * Functie om de enemy spawning aan te zetten en de resource systeem te starten
     * </summary>
     */
    public void EnableEnemySpawn()
    {
        _enemySpawn.SetActive(true);
        _startButton.SetActive(false);
        _resourceIndicator.SetActive(true);
        _gameStarted = true;
        gameObject.GetComponent<Resources>().resourceCounter = 10;
    }

    /**
     * <summary>
     * Houd de resource aantal op 0, zodat je niet kan bouwen voor de game start
     * </summary>
     * <returns></returns>
     */
    void Update()
    {
        if(!_gameStarted)
        {
            if(gameObject.GetComponent<Resources>().resourceCounter != 0)
            {
                gameObject.GetComponent<Resources>().resourceCounter = 0;
            }
        }
        else
        {
            
        }
    }
}
