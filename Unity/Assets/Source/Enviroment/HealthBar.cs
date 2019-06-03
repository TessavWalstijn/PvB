using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image _healthBarGreenPart;

    [SerializeField]
    private GameObject _gameOverScreen;

    [SerializeField]
    private GameObject _baseHealth;

    void Start()
    {
        _baseHealth = GameObject.Find("BaseHealth");
        _gameOverScreen = GameObject.Find("GameOver");
    }

    void Update()
    {
        float healthFloat = (Mathf.Round(_baseHealth.GetComponent<Health>().currentHealth) / 100);
        _healthBarGreenPart.fillAmount = healthFloat;

        if(healthFloat == 0)
        {
            _gameOverScreen.GetComponent<Image>().enabled = true;
        }
    }
}
