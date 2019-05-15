using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int _waves = 0;

    // Spawn time in seconds
    [SerializeField]
    private float _spawnTime = 2;

    //#region Wave events
    // Triggers an event if the wave hits that number
    // - Lanes
    [SerializeField]
    private int _unlockTopLane = 2;
    [SerializeField]
    private int _unlockBotLane = 6;
    [SerializeField]
    // - Enemies
    private int _unlockMidiumEnemy = 4;
    [SerializeField]
    private int _unlockHeavyEnemy = 8;
    [SerializeField]
    private int _winGame = 10;
    //#endregion

    //#region Wave variables.
    // Keep track of the wave.
    private double _maxEnemiesWave = 0;
    private int _totalEnemiesWave = 0;
    //#endregion

    private int _laneSpawning = 0;

    // If top road is unlocked
    private bool _topRoad = false;
    // If bot road is unlocked
    private bool _botRoad = false;
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

    // Midium enemy to spawn in the map
    [SerializeField]
    private GameObject _midiumEnemy;

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
        StartCoroutine(_SpawnRoutine(_spawnTime));
    }

    /**
     * <summary>
     * Spawns an enemy with the path and side it needs to walk on.
     * </summary>
     * <param name="path">The number of the path it walks on.</param>
     * <param name="side">The name of the side it walks on.</param>
     */
    private void _SpawnEnemy (int path, string side)
    {
        _totalEnemiesWave += 1;
        Transform[] road = _roads.GetEnemyRoad(path, side);

        GameObject enemy = Instantiate(_lightEnemy, road[0].position, road[0].rotation);
        enemy.GetComponent<EnemyMovement>().SetUp(road);

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
        _totalEnemiesWave = 1;
        _maxEnemiesWave = (5 * (_waves ^ 2) + 50 * _waves + 100) * 0.2;
        _waves++;

        if (_waves == _unlockTopLane) { _topRoad = true; }
        if (_waves == _unlockBotLane) { _botRoad = true; }
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
            yield return new WaitForSeconds(time);
            
            if (_left[_laneSpawning] == spawning.Main) {
                _SpawnEnemy(0, "left");
            }

            if (_right[_laneSpawning] == spawning.Main) {
                _SpawnEnemy(0, "right");
            }

            if (_topRoad) {
                if (_left[_laneSpawning] == spawning.Top) {
                    _SpawnEnemy(1, "left");
                }

                if (_right[_laneSpawning] == spawning.Top) {
                    _SpawnEnemy(1, "right");
                }
            }

            if (_botRoad) {
                if (_left[_laneSpawning] == spawning.Bot) {
                    _SpawnEnemy(2, "left");
                }

                if (_right[_laneSpawning] == spawning.Bot) {
                    _SpawnEnemy(2, "right");
                }
            }

            _laneSpawning += 1;
            if (_laneSpawning > 25) { _laneSpawning = 0; }
        }
    }
}