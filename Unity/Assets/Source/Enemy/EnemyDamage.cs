using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private bool _dead = false;

    [SerializeField]
    private int _damage = 100;

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
            }

            yield return new WaitForSeconds(time);
        }
    }

    public void StartDamage ()
    {
        StartCoroutine(_SpawnRoutine(_attackTime));
    }
}
