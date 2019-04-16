using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualConnections : MonoBehaviour
{
    
    [SerializeField]
    private bool _visualEnabled = true;

    [SerializeField]
    private Color _open;

    [SerializeField]
    private Color _closed;

    [SerializeField]
    private Color _move;

    [SerializeField]
    private Color _current;

    private Waypoints _waypoints;
    private Material[] _matirials = new Material[15];

    // Start is called before the first frame update
    void Start()
    {
        // _waypoints = GetComponent<Waypoints>();
        // GameObject[] waypoints = _waypoints.waypoints;

        // int maxWaypoints = waypoints.Length;
        // for (int i = 0; i < maxWaypoints; i += 1)
        // {
        //     GameObject point = waypoints[i];
        //     GameObject visual = point.transform.Find("Sphere").gameObject;
        //     _matirials[i] = visual.GetComponent<Renderer>().material;
        // }

        // // We know that the player starts at 0
        // ShowAvailbleConnections(0);
    }

    public void ShowAvailbleConnections(int waypoint)
    {
        // int[] connections = _waypoints.GetAvailbleEnemyConnections(waypoint);
        // Debug.Log(connections[0] + " " + connections[1]);

        // int maxWaypoints = _matirials.Length;
        // for (int i = 0; i < maxWaypoints; i += 1) {
        //     _matirials[i].color = _closed;
        // }

        // int maxConnections = connections.Length;
        // for (int i = 1; i < maxConnections; i += 1) {
        //     _matirials[connections[i]].color = _open;
        // }

        // _matirials[connections[0]].color = _current;
    }

    public void ShowMove(int pos)
    {
        // int maxWaypoints = _matirials.Length;
        // for (int i = 0; i < maxWaypoints; i += 1) {
        //     _matirials[i].color = _closed;
        // }

        // _matirials[pos].color = _move;
    }
}