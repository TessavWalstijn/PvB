using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _enemyHealth : EnemyMovement
{

   
    public int _enemyhealth = 20;
    private Tower _tower;
    // Start is called before the first frame update
    void Start()
    {
        _tower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyhealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void _takeDamage()
    {
       //_enemyhealth - Tower._damage; 
    }
}
