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

    /**
     * <summary>
     * Start functie om te zoeken naar de gameobjecten.
     * </summary>
     * <returns></returns>
     */
    void Start()
    {
        _baseHealth = GameObject.Find("BaseHealth");
        _gameOverScreen = GameObject.Find("GameOver");
    }

    /**
     * <summary>
     * Update functie om de healthbar van je basis te vullen met het aantal levenspunten dat het op dat moment bezit.
     * </summary>
     * <returns></returns>
     */
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
