using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int _waves = 0;

    // Spawn time in seconds
    [SerializeField]
    private float _minSpawnTime = 2;
    // Spawn time in seconds
    [SerializeField]
    private float _maxSpawnTime = 6;

    //#region Wave events
    // Triggers an event if the wave hits that number
    // - Lanes
    [SerializeField]
    private int _unlockTopLane = 3;
    [SerializeField]
    private int _unlockBotLane = 6;
    [SerializeField]
    private int _unlockHeavyEnemy = 5;
    [SerializeField]
    private int _winGame = 10;
    //#endregion

    //#region Wave variables.
    // Keep track of the wave.
    private double _maxEnemiesWave = 0;
    private int _totalEnemiesWave = 0;
    //#endregion

    // Switching to heavy enemy
    private int _heavyEnemySwitch = 7;
    private int _heavyEnemyCounter = 0;
    // Where enemy is going to spawn counter
    private int _laneSpawning = 0;
    // If top road is unlocked
    private bool _topRoad = false;
    // If bot road is unlocked
    private bool _botRoad = false;
    // If heavy enemy unlocks
    private bool _enemyUnlock = false;
    // If the game hits the final wave no more enemy spawns
    private bool _finalWave = false;

    // Type if or where enemy spawns
    private enum spawning { None, Top, Main, Bot };
    private Waypoints _roads;

    // Where an enemy spawns at the left side
    [SerializeField]
    private spawning[] _left;

    // Where an enemy spawns at the right side
    [SerializeField]
    private spawning[] _right;

    // Light enemy to spawn in the map
    [SerializeField]
    private GameObject _lightEnemy;

    // Heavy enemy to spawn in the map
    [SerializeField]
    private GameObject _heavyEnemy;

    /**
     * <summary>
     * Awake is called when the script instance is being loaded.
     * </summary>
     */
    void Awake()
    {
        _SetNewWave();
        _roads = gameObject.GetComponent<Waypoints>();
        // _GetPathLength();
    }

    /**
     * <summary>
     * Start is called before the first frame update
     * </summary>
     */
    void Start()
    {
        StartCoroutine(_SpawnRoutine(_maxSpawnTime));
    }

    /**
     * <summary>
     * Calculates the new time for the wave
     * </summary>
     * <param name="wave">Current wave number</param>
     * <param name="minWave">Minimal wave (where you start)</param>
     * <param name="maxWave">Win condition wave number</param>
     * <param name="minTime">Minimal spawn time</param>
     * <param name="maxTime">Maximal spawn time</param>
     * <returns></returns>
     */
    private float _MapSpawnTime (float wave, float minWave, float maxWave, float minTime, float maxTime)
    {
        float n = wave;
        float start1 = minWave;
        float stop1 = maxWave;
        float start2 = 0;
        float stop2 = maxTime - minTime;

        return _Map(n, start1, stop1, start2, stop2);
    }

    /**
     * <summary>
     * Re-maps a number from one range to another
     * </summary>
     * <param name="n">The incoming value to be converted</param>
     * <param name="start1">Lower bound of the value's current range</param>
     * <param name="stop1">Upper bound of the value's current range</param>
     * <param name="start2">Lower bound of the value's target range</param>
     * <param name="stop2">Upper bound of the value's target range</param>
     * <returns></returns>
     */
    private float _Map (float n, float start1, float stop1, float start2, float stop2)
    {
        return (n - start1) / (stop1 - start1) * (stop2 - start2) + start2;
    }

    /**
     * <summary>
     * Spawns an enemy with the path and side it needs to walk on.
     * </summary>
     * <param name="path">The number of the path it walks on.</param>
     * <param name="side">The name of the side it walks on.</param>
     */
    private void _SpawnEnemy (int path, string side, string type)
    {
        GameObject enemy;
        Transform[] road = _roads.GetEnemyRoad(path, side);

        if (type == "normal") {
            enemy = Instantiate(_lightEnemy, road[0].position, road[0].rotation);
        } else {
            enemy = Instantiate(_heavyEnemy, road[0].position, road[0].rotation);
        }

        enemy.GetComponent<EnemyMovement>().SetUp(road);

        _totalEnemiesWave += 1;
        if (_totalEnemiesWave >= _maxEnemiesWave) {
            _SetNewWave();
        }
    }

    /**
     * <summary>
     * Calculates and unlocks the new wave perks
     * </summary>
     */
    private void _SetNewWave ()
    {
        _totalEnemiesWave = 2;
        _maxEnemiesWave = (5 * (_waves ^ 2) + 50 * _waves + 100) * 0.2;
        _waves++;

        if (_waves == _unlockTopLane) { _topRoad = true; }
        if (_waves == _unlockBotLane) { _botRoad = true; }
        if (_waves == _unlockHeavyEnemy) { _enemyUnlock = true; }
        if (_waves == _winGame) {
            Debug.Log("Waves ended");
            _finalWave = true;
        }
    }

    /**
     * <summary>
     * IEnumarator that handels the spawn interfal.
     * </summary>
     * <param name="time">Seconds for the next enemy spawn</param>
     * <returns></returns>
     */
    private IEnumerator _SpawnRoutine (float time)
    {
        // Stops if the game is won!
        while (!_finalWave)
        {
            float respawnTime = _MapSpawnTime(_waves, 1, (float)_winGame -1f, _minSpawnTime, _maxSpawnTime);
            // Debug.Log(time - respawnTime);

            string type = "normal";
            if (_enemyUnlock) {
                if (_heavyEnemySwitch == _heavyEnemyCounter) {
                    if (_heavyEnemySwitch > 1) { 
                        _heavyEnemySwitch -= 1;
                    }
                    _heavyEnemyCounter = 0;
                    type = "heavy";
                }
                _heavyEnemyCounter += 1;
            }
            
            if (_left[_laneSpawning] == spawning.Main) {
                _SpawnEnemy(0, "left", type);
            }

            if (_right[_laneSpawning] == spawning.Main) {
                _SpawnEnemy(0, "right", type);
            }

            if (_topRoad) {
                if (_left[_laneSpawning] == spawning.Top) {
                    _SpawnEnemy(1, "left", type);
                }

                if (_right[_laneSpawning] == spawning.Top) {
                    _SpawnEnemy(1, "right", type);
                }
            }

            if (_botRoad) {
                if (_left[_laneSpawning] == spawning.Bot) {
                    _SpawnEnemy(2, "left", type);
                }

                if (_right[_laneSpawning] == spawning.Bot) {
                    _SpawnEnemy(2, "right", type);
                }
            }

            _laneSpawning += 1;
            if (_laneSpawning > 25) { _laneSpawning = 0; }

            yield return new WaitForSeconds(time - respawnTime);
        }
    }
}