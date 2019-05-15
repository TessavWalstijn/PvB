using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceOverTime : MonoBehaviour
{
    // integer genaamd _resources
    public int _resources;
    private float _startTime;
    [SerializeField]private Text _resourceText;
    [SerializeField]private int _rsIncreasepersecond;
    
    // _resources word op 0 gezet en de tijd begint te lopen
    void Start()
    {
        _resources = 0;
        _startTime = Time.time;
    }
    // iedere seconde komt een bepaalde waarde bij _resources erbij en word het op het scherm laten zien
    void Update()
    {
        _resources = _rsIncreasepersecond * (int)(Time.time - _startTime);
        _resourceText.text = "resources:" + _resources;
    }
}
