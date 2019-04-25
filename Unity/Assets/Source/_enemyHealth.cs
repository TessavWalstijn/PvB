using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _enemyHealth : EnemyMovement
{

   
    public int _enemyhealth = 20;
    private Tower _tower;
    void Start()
    {
        _tower = GetComponent<Tower>();
    }

    void Update()
    {
        if (_enemyhealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void _takeDamage()
    {
        
    }
}
