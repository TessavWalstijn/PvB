using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int _waves = 0;

    // Spawn tijd in seconden
    [SerializeField]
    private float _minSpawnTime = 2;
    // Spawn tijd in seconden
    [SerializeField]
    private float _maxSpawnTime = 6;

    //#region Wave events
    // Triggered een wave als het nummer correspondeerd.
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
    // Houd de wave nummer bij
    private double _maxEnemiesWave = 0;
    private int _totalEnemiesWave = 0;
    //#endregion

    // Wisselt naar heavy enemy
    private int _heavyEnemySwitch = 7;
    private int _heavyEnemyCounter = 0;
    // Counter om aan te duiden waar de vijand gaat spawnen
    private int _laneSpawning = 0;
    // Als de bovenste weg enabled is
    private bool _topRoad = false;
    // Als de onderste weg enabled is
    private bool _botRoad = false;
    // If heavy enemy unlocks
    private bool _enemyUnlock = false;
    // Stopt enemy spawner als de laatste wave start
    private bool _finalWave = false;

    // Type of de vijanden kunnen spawnen of waar de vijanden spawnen
    private enum spawning { None, Top, Main, Bot };
    private Waypoints _roads;

    // Waar de vijand aan de linkerkant spawned
    [SerializeField]
    private spawning[] _left;

    // Waar de vijand aan de rechterkant spawned
    [SerializeField]
    private spawning[] _right;

    // Lichte vijand gameobject referentie
    [SerializeField]
    private GameObject _lightEnemy;

    // Zware vijand gameobject referentie
    [SerializeField]
    private GameObject _heavyEnemy;

    /**
     * <summary>
     * Awake wordt geroepen wanneer de instance aangeroepen wordt
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
     * Start wordt aangeroepen voor de eerste frame
     * </summary>
     */
    void Start()
    {
        StartCoroutine(_SpawnRoutine(_maxSpawnTime));
    }

    /**
     * <summary>
     * Berekent de tijd voor de wave
     * </summary>
     * <param name="wave">Huidige wave nummer</param>
     * <param name="minWave">Minimale wave (waar je start)</param>
     * <param name="maxWave">Win conditie wave number</param>
     * <param name="minTime">Minimale spawn tijd</param>
     * <param name="maxTime">Maximale spawn tijd</param>
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
     * Herschaalt een nummer van één maat naar een andere maat
     * </summary>
     * <param name="n">Het huidige nummer dat omgezet moet worden</param>
     * <param name="start1">Laagste waarde van de huidige maat</param>
     * <param name="stop1">Hoogste waarde van de huidige maat</param>
     * <param name="start2">Laagste waarde van de gewenste maat</param>
     * <param name="stop2">Hoogste waarde van de gewenste maat</param>
     * <returns></returns>
     */
    private float _Map (float n, float start1, float stop1, float start2, float stop2)
    {
        return (n - start1) / (stop1 - start1) * (stop2 - start2) + start2;
    }

    /**
     * <summary>
     * Spawnt een enemy met het pad van één van de zijdes
     * </summary>
     * <param name="path">Het nummer van het huidige pad waar de vijand op loopt</param>
     * <param name="side">De naam van de kant waar de vijand op loopt</param>
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
     * Berekent en enabled de nieuwe wave instellingen
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
            //Debug.Log("Waves ended");
            _finalWave = true;
        }
    }

    /**
     * <summary>
     * IEnumarator dat de spawn interval regelt
     * </summary>
     * <param name="time">Seconden tot de nieuwe vijand spawnt</param>
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