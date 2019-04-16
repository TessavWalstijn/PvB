using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectingCursor : MonoBehaviour {

	private GameObject _cursor;

	void Start()
	{
		_cursor = GameObject.Find("CursorHolder");
		_cursor.SetActive(false);
	}

	void Update()
	{
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

		RaycastHit hit;
		if(Physics.Raycast(ray, out hit))
		{
			_cursor.SetActive(true);
			_cursor.transform.position = hit.point;
			_cursor.transform.up = hit.normal;
			Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);

			if(hit.transform.gameObject.tag == "Building")
			{
				_cursor.transform.position = hit.transform.position;
				_cursor.transform.rotation = hit.transform.rotation;
				if(Input.GetKeyDown(KeyCode.Space))
				{
					// Functie voor bouwen
				}
			}
		}
		else
		{
			_cursor.SetActive(false);
		}
	}
}
