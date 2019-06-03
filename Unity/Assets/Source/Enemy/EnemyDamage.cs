using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    private bool _dead = false;

    [SerializeField] private Image _gameOverScreen;

    [SerializeField]
    private int _damage = 20;

    [SerializeField]
    private int _attackTime = 2;

    [SerializeField]
    private GameObject _baseObject;
    private Health _baseHealth;
    private Health _enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        _baseHealth = _baseObject.GetComponent<Health>();
        _enemyHealth = gameObject.GetComponent<Health>();

        _gameOverScreen = GameObject.Find("GameOver").GetComponent<Image>();
        
        if(_baseHealth.currentHealth != 0)
            _gameOverScreen.enabled = false;

        Debug.Log(_baseHealth.currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (_dead) return;

        if (_enemyHealth.currentHealth <= 0) {
            _dead = true;
        }
    }

    /**
     * <summary>
     * IEnumarator that handels the damage interfal.
     * </summary>
     * <param name="time">Seconds for the next atteck</param>
     * <returns></returns>
     */
    private IEnumerator _SpawnRoutine (float time)
    {
        // Stops if the enemy is dead!
        while (!_dead)
        {
            if ( _baseHealth.currentHealth > 0 ) {
                _baseHealth.currentHealth -= _damage;
            } else {
                // TODO: Add Game OVER
                Debug.Log("Game over");
                _gameOverScreen.enabled = true;
            }

            yield return new WaitForSeconds(time);
        }
    }

    public void StartDamage ()
    {
        StartCoroutine(_SpawnRoutine(_attackTime));
    }
}
