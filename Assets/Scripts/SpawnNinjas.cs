using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNinjas : MonoBehaviour
{
    public Transform nodes;
    int numnodes;
    public List<Transform> nodeList;
    public Transform[] spots;
    public int spot;
    bool hasSpot;

    // Start is called before the first frame update
    void Start()
    {
        hasSpot = false;

        // put all the nodes in an array
        foreach(Transform node in nodes)
        {
            nodeList.Add(node);
        }
        spots = nodeList.ToArray();

        // get number of nodes
        numnodes = spots.Length;

         while (hasSpot == false)
        {
            // randonly generate a spot
            spot = Random.Range(0, numnodes);

            // check if spot is occupied
            if (spots[spot].GetComponent<Occupied>().occupied == false)
            {
                spots[spot].GetComponent<Occupied>().occupied = true;
                this.transform.position = spots[spot].position;
                hasSpot = true;
            }
        }
    }
}
