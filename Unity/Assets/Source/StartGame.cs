using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemySpawn;

    void Start()
    {
        _enemySpawn.SetActive(false);
    }

    public void EnableEnemySpawn()
    {
        _enemySpawn.SetActive(true);
    }
}
