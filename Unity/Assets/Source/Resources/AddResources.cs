using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddResources : MonoBehaviour
{
    [SerializeField]private int _makeResources = 50;
    private ResourceOverTime _resource;
    private float _startTimeAdd;
    
    void Start()
    {
        // defineren van het ResourceOverTime script 
       _resource = GameObject.Find("Resource-Manager").GetComponent<ResourceOverTime>();
       // start tellen van de tijd
        _startTimeAdd = Time.time;
        // na 5 seconden word de functie AddResourcesOverTime uitgevoerd
        InvokeRepeating("AddResourcesOverTime", 1f, 1f);
    }

    void AddResourcesOverTime()
    {
        // resource van ResourceOverTime script krijgt het getal van _makeResources erbij opgetelt
         Debug.Log("add resources");
        _resource._resources += _makeResources;
    }
}