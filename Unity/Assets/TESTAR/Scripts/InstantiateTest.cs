using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTest : MonoBehaviour
{

    public GameObject _object;
    public float scaleModifier = 0.5f;

    void Start()
    {
       GameObject cube = Instantiate(_object, transform.position, transform.rotation);
       cube.transform.localScale = new Vector3(cube.transform.localScale.x * scaleModifier, cube.transform.localScale.y * scaleModifier, cube.transform.localScale.z * scaleModifier);
    }
}
