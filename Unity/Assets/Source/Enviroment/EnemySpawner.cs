using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int _waves = 0;

    // private int _waveIncremention = 1.2;

    [SerializeField]
    private int _minSpawntimeMS = 1000;

    [SerializeField]
    private int _maxSpawntimeMS = 5000;

    private int _timer = 0;
    private double _maxEnemiesWave = 0;
    private int _totalEnemiesWave = 0;

    [SerializeField]
    private GameObject _lightEnemy;

    [SerializeField]
    private GameObject _midiumEnemy;

    [SerializeField]
    private GameObject _heavyEnemy;

    void Awake()
    {
        _SetNewWave();
    }

    void Update()
    {
        if (_timer > 0) {
            _timer = 0;
            _SpawnEnemy();
        }

        _timer += 1;
    }

    private void _SpawnEnemy ()
    {
        _totalEnemiesWave += 1;

        Instantiate(_lightEnemy, transform.position, transform.rotation);

        if (_totalEnemiesWave >= _maxEnemiesWave) {
            _SetNewWave();
        }
    }

    private void _SetNewWave ()
    {
        _totalEnemiesWave = 0;
        _maxEnemiesWave = (5 * (_waves ^ 2) + 50 * _waves + 100) * 0.2;
        _waves++;
    }
}
