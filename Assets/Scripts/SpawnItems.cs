using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnItems : MonoBehaviour
{
    public GameObject silver;
    public GameObject gold;
    public GameObject sushi;
    public Transform nodes;

    int numnodes;
    public List<Transform> nodeList;
    Transform[] spots;
    HashSet<int> hs;
    // Start is called before the first frame update
    void Start()
    {
        // put all the nodes in an array
        foreach(Transform node in nodes)
        {
            nodeList.Add(node);
        }
        spots = nodeList.ToArray();

        // get number of nodes
        numnodes = spots.Length;

        // generate 6 random spots for the gold and sushi 
        hs = new HashSet<int>();  
        while(hs.Count<6) 
        { 
            hs.Add(Random.Range(0, numnodes)); 
        } 

        // for each node generate a silver coin, unless the value is in the hash set
        // then generate a gold coin or sushi depending on the number of gold or silver
        var goldcount = 0;
        for(int i = 0; i < numnodes; i++)
        {
            // check that spot isnt in the hash set
            // if it isn't then instantiate a silver coin
            if(!hs.Contains(i))
            {
                Instantiate(silver, spots[i].position, Quaternion.Euler(0f, 0f, 0f));
            }
            else if(goldcount < 3)
            {
                Instantiate(gold, spots[i].position, Quaternion.Euler(0f, 0f, 0f));
                goldcount++;
            }
            else
            {
                Instantiate(sushi, spots[i].position, Quaternion.Euler(0f, 0f, 0f));
            }
        } 

		GameObject uzai = GameObject.FindWithTag("Uzai");
		var uzaiItems = uzai.GetComponent<AIDestinationSetter>().items;
		GameObject[] findObj = GameObject.FindGameObjectsWithTag("Coin");
			
			for(int i = 0; i < findObj.Length; i++)
			{
				
				
				uzaiItems.Add(findObj[i]);
			}

	


    }
}
