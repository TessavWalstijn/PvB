using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Alle locaties op de weg
    [SerializeField]
    private GameObject[] _waypoints = new GameObject[15];
    public GameObject[] waypoints { get { return _waypoints; } }

    //#region Number configuratie voor de wegen
    [SerializeField]
    private int[] _topRoadL = new int[8];
    [SerializeField]
    private int[] _topRoadR = new int[8];

    [SerializeField]
    private int[] _mainRoadL = new int[7];
    [SerializeField]
    private int[] _mainRoadR = new int[7];

    [SerializeField]
    private int[] _botRoadL = new int[7];
    [SerializeField]
    private int[] _botRoadR = new int[7];
    //#endregion

    /**
     * <summary>
     * Zoekt naar de gevraagde weg
     * </summary>
     * <param name="road">[int] Geef het nummer van de weg: "top = 1", "main = 0" of "bot = 2"</param>
     * <param name="side">[string] Geef de naam van de zijde: "left" of "right"</param>
     * <returns>[Transform[]] Locaties om door te lopen</returns>
     */
    public Transform[] GetEnemyRoad (int road, string side)
    {
        if (side == "left") {
            switch (road) {
                case 1: 
                    return _Road(_topRoadL);
                default:
                case 0: 
                    return _Road(_mainRoadL);
                case 2:
                    return _Road(_botRoadL);
            }
        } else {
            switch (road) {
                case 1: 
                    return _Road(_topRoadR);
                default:
                case 0: 
                    return _Road(_mainRoadR);
                case 2:
                    return _Road(_botRoadR);
            }
        }
    }

    /**
     * <summary>
     * Verzameld de locatie van de wegen
     * </summary>
     * <param name="path">[int[]] nummers representeren de weg</param>
     * <returns>[Transform[]] Locaties</returns>
     */
    private Transform[] _Road(int[] path)
    {
        int length = path.Length;
        Transform[] road = new Transform[length];

        for (int i = 0; i < length; i += 1) {
            road[i] = _waypoints[path[i]].GetComponent<Waypoint>().location;
        }

        return road;
    }
}