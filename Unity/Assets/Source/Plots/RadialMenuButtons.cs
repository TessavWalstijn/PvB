using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuButtons : MonoBehaviour
{

    [Header("Towers")]
    [SerializeField] private GameObject _rapidFireTower;
    [SerializeField] private GameObject _areaOfEffectTower;
    [SerializeField] private GameObject _slowTower;

    [SerializeField] private GameObject _currentTower;

    [Header("Spawn Location")]
    [SerializeField] private GameObject _plot;
    private SelectPlot _plotScript;

    [Header("Other Variables")]
    public float scaleModifier;

    void Start()
    {
        scaleModifier = GameObject.Find("LevelHolder").GetComponent<LevelValues>().sliderScale;

        _plotScript = _plot.GetComponent<SelectPlot>();
    }

   public void RadialTopButton()
   {
       InstantiateTower(_rapidFireTower);
   }

   public void RadialBottomButton()
   {
       _plotScript.GetComponent<SelectPlot>().DisablePlot();
   }

   public void RadialRightButton()
   {
       _plotScript.GetComponent<SelectPlot>().DisablePlot();
   }

   public void RadialLeftButton()
   {
       InstantiateTower(_areaOfEffectTower);
   }

   public void BuiltTowerRadialRightButton()
   {
       Destroy(_currentTower.gameObject);
       _plotScript.GetComponent<SelectPlot>().DisablePlot();
       _plotScript.GetComponent<SelectPlot>()._plotHasBuilding = false;
   }

   private void InstantiateTower(GameObject tower)
   {
        GameObject _newRapidFireTower = Instantiate(tower, _plot.transform.position, _plot.transform.rotation);
        _newRapidFireTower.transform.localScale = new Vector3(_newRapidFireTower.transform.localScale.x * scaleModifier, _newRapidFireTower.transform.localScale.y * scaleModifier, _newRapidFireTower.transform.localScale.z * scaleModifier);
        _newRapidFireTower.transform.parent = _plot.transform;

        _currentTower = _newRapidFireTower;

       _plotScript.GetComponent<SelectPlot>().DisablePlot();
       _plotScript.GetComponent<SelectPlot>()._plotHasBuilding = true;
   }
}
