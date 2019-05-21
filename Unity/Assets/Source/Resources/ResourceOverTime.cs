using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceOverTime : MonoBehaviour
{
    // integer genaamd _resources
    public int _resources;
    // tekst waar de resources op worden afgebeeld
    [SerializeField]private Text _resourceText;
    private ResourceOverTime _resource;
    
    // _resources word op 0 gezet en de tijd begint te lopen
    void Start()
    {
        _resources = 0;
        StartCoroutine(GetResources());
    }
   // de waarde van _resources word weergegeven op een textobject 
    void Update()
    {
         _resourceText.text = "resources:" + _resources;  
     
    }
    // iedere seconde word er 1 resource toegevoegd
    IEnumerator GetResources()
    {
        while(true)
        {
        yield return new WaitForSeconds(1);
        _resources = _resources + 1;
        Debug.Log("added");
        }
       
    }
}
 