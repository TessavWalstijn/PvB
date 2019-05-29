using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuButtons : MonoBehaviour
{
    // Referentie naar elke tower die geplaatst kan worden
    [Header("Towers")]
    [SerializeField] private GameObject _rapidFireTower;
    [SerializeField] private GameObject _areaOfEffectTower;

    // Referentie naar de tower die op dat moment gebouwd is
    [SerializeField] private GameObject _currentTower;

    // Referentie naar de locatie waar het object neergezet wordt
    [Header("Spawn Location")]
    [SerializeField] private GameObject _plot;

    // Referentie naar het script: SelectPlot
    private SelectPlot _plotScript;

    // Referentie naar de schaling van de UI slider, om de objecten te spawnen met het juiste formaat.
    [Header("Other Variables")]
    public float scaleModifier;

    void Start()
    {
        scaleModifier = GameObject.Find("LevelHolder").GetComponent<LevelValues>().sliderScale;

        _plotScript = _plot.GetComponent<SelectPlot>();
    }

   public void RadialTopButton()        // Button functie voor het instantiëren
   {
       _plotScript.GetComponent<SelectPlot>().DisablePlot();
   }

   public void RadialBottomButton()     // Button functie voor het instantiëren
   {
       _plotScript.GetComponent<SelectPlot>().DisablePlot();
   }

   public void RadialRightButton()      // Button functie voor sluiten van de UI
   {
       InstantiateTower(_areaOfEffectTower);
   }

   public void RadialLeftButton()       // Button functie voor het instantiëren
   {
       InstantiateTower(_rapidFireTower);
   }

   public void BuiltTowerRadialBottomButton()        // Button functie voor het weghalen van de tower die op dat moment staat op de plot
   {
       Destroy(_currentTower.gameObject);
       _plotScript.GetComponent<SelectPlot>().DisablePlot();
       _plotScript.GetComponent<SelectPlot>().plotHasBuilding = false;
   }

   private void InstantiateTower(GameObject tower)      // Functie om de juiste tower de instantiëren op de plek van het geselecteerde plot
   {
        GameObject _newTower = Instantiate(tower, _plot.transform.position, _plot.transform.rotation);
        _newTower.transform.localScale = new Vector3(_newTower.transform.localScale.x * scaleModifier, _newTower.transform.localScale.y * scaleModifier, _newTower.transform.localScale.z * scaleModifier);
        _newTower.transform.parent = _plot.transform;

        _currentTower = _newTower;

       _plotScript.GetComponent<SelectPlot>().DisablePlot();
       _plotScript.GetComponent<SelectPlot>().plotHasBuilding = true;
   }
}
