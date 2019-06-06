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

    private GameObject _resourceManager;

    // Referentie naar de schaling van de UI slider, om de objecten te spawnen met het juiste formaat.
    [Header("Other Variables")]
    public float scaleModifier;

    /**
     * <summary>
     * Start functie om de waardes uit verschillende scripts op te slaan als referentie
     * </summary>
     * <returns></returns>
     */
    void Start()
    {
        scaleModifier = GameObject.Find("LevelHolder").GetComponent<LevelValues>().sliderScale;
        _resourceManager = GameObject.Find("GameManager");

        _plotScript = _plot.GetComponent<SelectPlot>();
    }

    /**
     * <summary>
     * Button functie voor sluiten van de UI menu
     * </summary>
     */
    public void DisablePlotUI()     
    {
       _plotScript.GetComponent<SelectPlot>().DisablePlot();
    }    

    /**
     * <summary>
     * // Button functie voor het instantiëren van de area of effect tower
     * </summary>
     */
    public void InstantiateAOETower()      
    {
       if(_resourceManager.GetComponent<Resources>().resourceCounter >= 5)
       {
           InstantiateTower(_areaOfEffectTower);
           _resourceManager.GetComponent<Resources>().resourceCounter -= 5;
       }
    }

    /**
     * <summary>
     * Button functie voor het instantiëren van de rapidfire tower
     * </summary>
     */
    public void InstantiateRapidFireTower()       
    {
       if(_resourceManager.GetComponent<Resources>().resourceCounter >= 5)
       {
           InstantiateTower(_rapidFireTower);
           _resourceManager.GetComponent<Resources>().resourceCounter -= 5;
       }
       
    }

    /**
     * <summary>
     * Button functie voor het weghalen van de tower die op dat moment staat op de plot
     * </summary>
     */
    public void DestroyBuiltTower()
    {
       Destroy(_currentTower.gameObject);
       _resourceManager.GetComponent<Resources>().resourceCounter += 3;
       _plotScript.GetComponent<SelectPlot>().DisablePlot();
       _plotScript.GetComponent<SelectPlot>().plotHasBuilding = false;
    }

    /**
     * <summary>
     * Functie om de juiste tower de instantiëren op de plek van het geselecteerde plot
     * </summary>
     * <param name="tower">de tower refereert naar het object van de instantiate functie</param>
     */
    private void InstantiateTower(GameObject tower)      
    {
        GameObject _newTower = Instantiate(tower, _plot.transform.position, _plot.transform.rotation);
        _newTower.transform.localScale = new Vector3(_newTower.transform.localScale.x * scaleModifier, _newTower.transform.localScale.y * scaleModifier, _newTower.transform.localScale.z * scaleModifier);
        _newTower.transform.parent = _plot.transform;

        _currentTower = _newTower;

       _plotScript.GetComponent<SelectPlot>().DisablePlot();
       _plotScript.GetComponent<SelectPlot>().plotHasBuilding = true;
    }
}
