using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    //public int minimum;
    public int maximum;
    public int current;
    public Image mask;

    public Image fill;
    public Color color;

    // Grab current Score from ScoreManager
    // Using this video - https://youtu.be/oAgW1GUDhdc
    public ScoreManager grabCurrentScore;


    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        maximum = 1000;

        // Give a 1 second delay so the coins can populate, to then calculate total points possible
        // Coins populate in the AIDestinationSetter.cs script
        Invoke("TotalPoints", 1);

    }

    // Updates the the scoreboard's maximum (total points possible)
    void TotalPoints()
    {
        //Grab the total number of coins on the board
        int total = GameObject.FindGameObjectsWithTag("Coin").Length;
//        Debug.Log("Progress Bar total coins: " + total);
        // Because there are 3 gold coins (worth 5 pts each),
        // we need to add the differnce
        total += (3*4);
        total += current;
        maximum = total;
//        Debug.Log("Progress Bar total points: " + total);
    }

    // Update is called once per frame
    void Update()
    {
        // Update score with every frame
        grabCurrentScore = FindObjectOfType< ScoreManager >();
        current = grabCurrentScore.score;

        GetCurrentFill();
    }

    void GetCurrentFill()
    {
       // float currentOffset = current - maximum;
       // float maximumOffset = maximum - minimum;
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;

        // Changes the color of the progress bar
        fill.color = color;
    }
}
