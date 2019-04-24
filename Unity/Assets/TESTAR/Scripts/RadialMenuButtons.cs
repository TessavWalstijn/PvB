using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuButtons : MonoBehaviour
{

    [Header("Towers")]
    [SerializeField] private GameObject _rapidFireTower;
    [SerializeField] private GameObject _areaOfEffectTower;
    [SerializeField] private GameObject _slowTower;

    [Header("Spawn Location")]
    [SerializeField] private GameObject _plot;

   public void RadialTopButton()
   {
       GameObject _newRapidFireTower = Instantiate(_rapidFireTower, _plot.transform.position, _plot.transform.rotation);
       _newRapidFireTower.transform.parent = _plot.transform;

       transform.GetComponentInParent<SelectPlot>().DisablePlot();
   }

   public void RadialBottomButton()
   {
       transform.GetComponentInParent<SelectPlot>().DisablePlot();
   }

   public void RadialRightButton()
   {
       transform.GetComponentInParent<SelectPlot>().DisablePlot();
   }

   public void RadialLeftButton()
   {
       transform.GetComponentInParent<SelectPlot>().DisablePlot();
   }
}
