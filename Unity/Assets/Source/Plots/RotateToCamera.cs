using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{

    private Camera _camera;

    void Start()
    {
        _camera = GameObject.Find("ARCoreCamera").GetComponent<Camera>();
    }

    void Update()
    {
        transform.LookAt(new Vector3(_camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
    }
}
