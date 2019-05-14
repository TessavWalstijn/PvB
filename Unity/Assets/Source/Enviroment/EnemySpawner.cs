using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int _waves = 0;

    // private int _waveIncremention = 1.2;

    [SerializeField]
    private float _spawnTime = 2;

    [SerializeField]
    private int _unlockTopLane = 2;
    [SerializeField]
    private int _unlockBotLane = 6;
    [SerializeField]
    private int _unlockMidiumEnemy = 4;
    [SerializeField]
    private int _unlockHeavyEnemy = 8;

    private double _maxEnemiesWave = 0;
    private int _totalEnemiesWave = 0;
    private int _laneSpawning = 0;

    private bool _topRoad = false;
    private bool _botRoad = false;
    private enum spawning { None, Top, Main, Bot };
    private Waypoints _roads;

    [SerializeField]
    private spawning[] _left;

    [SerializeField]
    private spawning[] _right;

    [SerializeField]
    private GameObject _lightEnemy;

    [SerializeField]
    private GameObject _midiumEnemy;

    [SerializeField]
    private GameObject _heavyEnemy;

    void Awake()
    {
        _SetNewWave();
        _roads = gameObject.GetComponent<Waypoints>();
        StartCoroutine(_SpawnRoutine(_spawnTime));

        // _GetPathLength();
    }
    
    private void _GetPathLength ()
    {
        Transform[] leftTop = _roads.GetEnemyRoad(1, "left");
        Transform[] rightTop = _roads.GetEnemyRoad(1, "right");
        Transform[] leftMain = _roads.GetEnemyRoad(0, "left");
        Transform[] rightMain = _roads.GetEnemyRoad(0, "right");
        Transform[] leftBot = _roads.GetEnemyRoad(2, "left");
        Transform[] rightBot = _roads.GetEnemyRoad(2, "right");

        float distanceLeftTop = 0;
        float distanceRightTop = 0;
        float distanceLeftMain = 0;
        float distanceRightMain = 0;
        float distanceLeftBot = 0;
        float distanceRightBot = 0;

        for (int i = 0; i < 9; i += 1) {
            distanceLeftTop += Vector3.Distance(leftTop[i].transform.position, leftTop[i+1].transform.position);
        }

        for (int i = 0; i < 9; i += 1) {
            distanceRightTop += Vector3.Distance(rightTop[i].transform.position, rightTop[i+1].transform.position);
        }

        for (int i = 0; i < 6; i += 1) {
            distanceLeftMain += Vector3.Distance(leftMain[i].transform.position, leftMain[i+1].transform.position);
        }

        for (int i = 0; i < 9; i += 1) {
            distanceRightMain += Vector3.Distance(rightMain[i].transform.position, rightMain[i+1].transform.position);
        }

        // for (int i = 0; i < 10; i += 1) {
        //     distanceLeftBot += Vector3.Distance(leftBot[i].transform.position, leftBot[i+1].transform.position);
        // }

        // for (int i = 0; i < 10; i += 1) {
        //     distanceRightBot += Vector3.Distance(rightBot[i].transform.position, rightBot[i+1].transform.position);
        // }

        Debug.Log("\n" + distanceLeftMain + " <- main\n" + distanceLeftTop + " <- top");
        Debug.Log("\n" + distanceRightMain + " <- main\n" + distanceRightTop + " <- top");
        // Debug.Log("\n" + distanceLeftMain + " <- main\n" + distanceLeftBot + "<- left");
        // Debug.Log("\n" + distanceRightMain + " <- main\n" + distanceRightBot + "<- right");
    }

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

    private void _SetNewWave ()
    {
        _totalEnemiesWave = 0;
        _maxEnemiesWave = (5 * (_waves ^ 2) + 50 * _waves + 100) * 0.2;
        _waves++;

        if (_waves >= _unlockTopLane) { _topRoad = true; }
        if (_waves >= _unlockBotLane) { _botRoad = true; }
    }

    private IEnumerator _SpawnRoutine (float time)
    {
        while (true)
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