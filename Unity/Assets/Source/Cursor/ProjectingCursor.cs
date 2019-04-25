using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectingCursor : MonoBehaviour {

	[SerializeField] private GameObject _towerObject;
	private GameObject _cursor;
	private bool hitBuilding = false;

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

			if(hit.transform.gameObject.tag == "Building")
			{
				_cursor.transform.position = hit.transform.position;
				_cursor.transform.rotation = hit.transform.rotation;
				hitBuilding = true;
			}
			else
			{
				hitBuilding = false;
			}
		}
		else
		{
			_cursor.SetActive(false);
		}
	}

	public void BuildTowerOnCursor()
	{
		if(hitBuilding)
			Instantiate(_towerObject, _cursor.transform.position, _cursor.transform.rotation);
	}
}
