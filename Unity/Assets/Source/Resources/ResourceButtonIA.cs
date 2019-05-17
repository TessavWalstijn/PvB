using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceButtonIA : MonoBehaviour
{
    
    private ResourceOverTime _resource;
    [SerializeField]private Button _resourceButton;
    private int _towerPrice = 5;
    // aanroepen van het resourcescript en de button
    void Start()
    {
        _resource = GameObject.Find("Resource-Manager").GetComponent<ResourceOverTime>();
        _resourceButton.onClick.AddListener(TaskOnClick);
    }
    void Update()
    {
        // als _resourses boven 5 is word de knop ingeschakelt
        if(_resource._resources >= 5)
        {
            Debug.Log("Go ahead and click");
            _resourceButton.interactable = true;
        }else
        {
            _resourceButton.interactable = false;
        }
    }
    // resources worden van het totaal bedrag afgetrokken
    void TaskOnClick()
    {
         Debug.Log("remove resources");
        _resource._resources -= _towerPrice;
    }
   
}
