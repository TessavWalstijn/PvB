using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _waypoints = new GameObject[11];
    public GameObject[] waypoints { get { return _waypoints; } }

    private int[][] _connectionsEnemy = new int[11][];

    void Start()
    {
        // ~~ ALLOWED CONNECTIONS:
        // ~~ Array format: [A, B, ...[B]]
        // ~~ A = Enemy location
        // ~~ B = Allowed movement

        // ~~ Main Road connections
        _connectionsEnemy[0] = new int[] { 0, 1 };
        _connectionsEnemy[1] = new int[] { 1, 2 };
        _connectionsEnemy[2] = new int[] { 2, 3 };
        _connectionsEnemy[3] = new int[] { 3, 4 };
        _connectionsEnemy[4] = new int[] { 4, 5 };
        _connectionsEnemy[5] = new int[] { 5, 6 };

        // ~~ Bottom Road connections
        _connectionsEnemy[6] = new int[] { 7, 8 };
        _connectionsEnemy[7] = new int[] { 8, 9 };
        _connectionsEnemy[8] = new int[] { 9, 4 };

        // ~~ Top Road connections
        _connectionsEnemy[9] = new int[] { 10, 11 };
        _connectionsEnemy[9] = new int[] { 11, 12 };
        _connectionsEnemy[9] = new int[] { 12, 13 };
        _connectionsEnemy[9] = new int[] { 13, 3 };
    }

    public int[] GetAvailbleEnemyConnections(int waypoint)
    {
        int max = _connectionsEnemy.Length;
        for (int i = 0; i < max; i += 1)
        {
            int[] currentConnections = _connectionsEnemy[i];
            if (waypoint == currentConnections[0])
            {
                return currentConnections;
            }
        }
        return new int[] { waypoint };
    }
}