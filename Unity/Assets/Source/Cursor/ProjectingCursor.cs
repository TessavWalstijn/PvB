using UnityEngine;
using UnityEngine.UI;

public class ProjectingCursor : MonoBehaviour {

	// Referentie naar de button om een plot te selecteren
	[SerializeField] 
	private GameObject _selectButton;
	// Referentie naar de cursor die geprojecteerd wordt op het speelveld
	private GameObject _cursor;			

	// Boolean om te registreren of er wel of niet een gebouw is geraakt met de cursor
	private bool _hitBuilding = false;

	void Start()
	{
		// Referentie naar het cursor object wat geprojecteerd wordt op het speelveld, wat niet weergegeven wordt tot het cursor op een oppervlakte komt
		_cursor = GameObject.Find("CursorHolder");
		_cursor.SetActive(false);

		// Zet het selectieknop uit tot het plot raakt
		_selectButton.SetActive(false);
	}

	void Update()		
	{
		// Referentie naar de ray, die van de main camera kijkt
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

		// Referentie naar het gameobject wat geraakt wordt door de ray
		RaycastHit hit;
		// if statement om de goede rotatie en positie van de cursor te bepalen
		if(Physics.Raycast(ray, out hit))
		{
			_cursor.SetActive(true);
			_cursor.transform.position = hit.point;
			_cursor.transform.up = hit.normal;

			// if statement om te bepalen of een ray een plot raakt en ervoor te zorgen dat de cursor op het gebouw blijft
			if(hit.transform.gameObject.tag == "Building")
			{
				_cursor.transform.position = hit.transform.position;
				_cursor.transform.rotation = hit.transform.rotation;
				_hitBuilding = true;

				_selectButton.SetActive(true);
				// Zet de functie van de knop gelijk met welke gebouw of plot er wordt geselecteerd
				_selectButton.GetComponent<Button>().onClick.AddListener(()=>hit.transform.gameObject.GetComponent<SelectPlot>().EnablePlot());
			}
			else	// else statement die de functie van de knop weghaald als het niet meer geselecteerd wordt
			{
				_hitBuilding = false;
				_selectButton.GetComponent<Button>().onClick.RemoveAllListeners();
			}
		}
		else 	// set de cursor uit als de ray niks raakt
		{
			_cursor.SetActive(false);
		}
	}
}
