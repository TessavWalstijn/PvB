using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // All locations of the enemy road.
    [SerializeField]
    private GameObject[] _waypoints = new GameObject[15];
    public GameObject[] waypoints { get { return _waypoints; } }

    //#region Number configuration for the roads
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
     * Vigures out the requested road.
     * </summary>
     * <param name="road">[int] Give the number of the road: "top = 1", "main = 0" or "bot = 2"</param>
     * <param name="side">[string] Give the name of the side "left" or "right"</param>
     * <returns>[Transform[]] Locations to walk through</returns>
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
     * Collects the locations of the road.
     * </summary>
     * <param name="path">[int[]] numbers representing locations</param>
     * <returns>[Transform[]] Locations</returns>
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