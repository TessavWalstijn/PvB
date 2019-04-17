using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawning : MonoBehaviour {


    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject spawnpoint;
    [SerializeField]
    private int waveNumber;
    [SerializeField]
    private int spawnAmount;


	void Start () {
        waveNumber += 1;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
