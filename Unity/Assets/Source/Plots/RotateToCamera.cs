using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    // Referentie naar de camera
    private Camera _camera;

    void Start()
    {
        // Zoekt naar de Augmented Reality camera
        _camera = GameObject.Find("ARCoreCamera").GetComponent<Camera>();
    }

    void Update()
    {
        // Roteert naar de AR Camera
        transform.LookAt(new Vector3(_camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
    }
}
