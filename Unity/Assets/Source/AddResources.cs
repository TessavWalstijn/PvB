using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddResources : MonoBehaviour
{

    private float _startTimeAdd;
    [SerializeField]private int _makeResources = 50;
    private int _tempInt;
    private ResourceOverTime _resource;
    
    void Start()
    {
        // defineren van het ResourceOverTime script 
       _resource = GameObject.Find("Resource-Manager").GetComponent<ResourceOverTime>();
       // start tellen van de tijd
        _startTimeAdd = Time.time;
        // na 5 seconden word de functie AddResourcesOverTime uitgevoerd
        InvokeRepeating("AddResourcesOverTime", 5f, 5f);
    }

    void AddResourcesOverTime()
    {
        // resource van ResourceOverTime script krijgt het getal van _makeResources erbij opgetelt
         Debug.Log("add resources");
        _resource._resources += _makeResources;
    }
}
