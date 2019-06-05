using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    // Referentie naar de camera
    private Camera _camera;

    /**
     * <summary>
     * Start functie die zoekt naar de ARCore Camera.
     * </summary>
     * <returns></returns>
     */
    void Start()
    {
        _camera = GameObject.Find("ARCoreCamera").GetComponent<Camera>();
    }

    /**
     * <summary>
     * Update functie dat het object blijft roteren naar de camera
     * </summary>
     * <returns></returns>
     */
    void Update()
    {
        transform.LookAt(new Vector3(_camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
    }
}
