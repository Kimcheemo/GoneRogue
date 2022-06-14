using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    // Full and empty hearts
    public GameObject fullHeart;
    public GameObject emptyHeart;
    // Location of hearts
     Vector3 location1;
     Vector3 location2;
     Vector3 location3;
     GameObject heart1;
     GameObject heart2;
     GameObject heart3;

     // number of lives during game
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        // get current lives
        lives = PlayerPrefs.GetInt("Lives");

        if (lives == 3)
        {
            // Instantiate hearts
            location1 = new Vector3(-14.5f, -9.51f, 0f);
            heart1 = Instantiate(fullHeart, location1, Quaternion.Euler(0f, 0f, 0f));

            location2 = new Vector3(-13.0f, -9.51f, 0f);
            heart2 = Instantiate(fullHeart, location2, Quaternion.Euler(0f, 0f, 0f));

            location3 = new Vector3(-11.5f, -9.51f, 0f);
            heart3 = Instantiate(fullHeart, location3, Quaternion.Euler(0f, 0f, 0f));
        }

        if (lives == 2)
        {
            // Instantiate hearts
            location1 = new Vector3(-14.5f, -9.51f, 0f);
            heart1 = Instantiate(fullHeart, location1, Quaternion.Euler(0f, 0f, 0f));

            location2 = new Vector3(-13.0f, -9.51f, 0f);
            heart2 = Instantiate(fullHeart, location2, Quaternion.Euler(0f, 0f, 0f));

            location3 = new Vector3(-11.5f, -9.51f, 0f);
            heart3 = Instantiate(emptyHeart, location3, Quaternion.Euler(0f, 0f, 0f));
        }

        if (lives == 1)
        {
            // Instantiate hearts
            location1 = new Vector3(-14.5f, -9.51f, 0f);
            heart1 = Instantiate(fullHeart, location1, Quaternion.Euler(0f, 0f, 0f));

            location2 = new Vector3(-13.0f, -9.51f, 0f);
            heart2 = Instantiate(emptyHeart, location2, Quaternion.Euler(0f, 0f, 0f));

            location3 = new Vector3(-11.5f, -9.51f, 0f);
            heart3 = Instantiate(emptyHeart, location3, Quaternion.Euler(0f, 0f, 0f));
        }
        
        
    }
}
