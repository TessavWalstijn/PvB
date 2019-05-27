using UnityEngine;
using UnityEngine.UI;

public class ProjectingCursor : MonoBehaviour {

	[SerializeField] private GameObject _towerObject;
	[SerializeField] private GameObject _level;
	[SerializeField] private GameObject _selectButton;

	private GameObject _cursor;
	private bool hitBuilding = false;

	void Start()
	{
		_cursor = GameObject.Find("CursorHolder");
		_cursor.SetActive(false);

		_selectButton.SetActive(false);
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

				_selectButton.SetActive(true);
				_selectButton.GetComponent<Button>().onClick.AddListener(()=>hit.transform.gameObject.GetComponent<SelectPlot>().EnablePlot());
			}
			else
			{
				hitBuilding = false;
				_selectButton.GetComponent<Button>().onClick.RemoveAllListeners();
			}
		}
		else
		{
			_cursor.SetActive(false);
		}
	}
	/*
	public void BuildTowerOnCursor()
	{
		if(hitBuilding)
		{
			GameObject _newTower = Instantiate(_towerObject, _cursor.transform.position, _cursor.transform.rotation);
			_newTower.transform.parent = _level.transform;
			_newTower.transform.localScale = new Vector3(_newTower.transform.localScale.x * scaleModifier, _newTower.transform.localScale.y * scaleModifier, _newTower.transform.localScale.z * scaleModifier);
		}
	}
	*/
}
