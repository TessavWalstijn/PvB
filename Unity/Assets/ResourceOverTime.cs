using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceScript : MonoBehaviour
{
    private int _resources;
    private float _startTime;
    [SerializeField]private Text _resourceText;
    [SerializeField]private int _rsIncreasepersecond;
    
    void Start()
    {
        _resources = 0;
        _startTime = Time.time;
    }

    void Update()
    {
        _resources = _rsIncreasepersecond * (int)(Time.time - _startTime);
        _resourceText.text = "resources:" + _resources;
    }
}
