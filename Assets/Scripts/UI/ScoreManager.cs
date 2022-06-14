using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    // This allows you to write in the text UI
    public TextMeshProUGUI text;
    // This is the amount of coins there is in total
    public int score = 0;

    // Grabbing info from Progress bar
    //public ProgressBar progress;

 
    

    // Start is called before the first frame update
    void Start()
    {
        // Grab the total amount of coins - from progress bar's Maximum input
        // Using this video  - https://youtu.be/oAgW1GUDhdc
        //progress = FindObjectOfType< ProgressBar >();
        //score = progress.maximum;
        //Debug.Log(progress.maximum);

        if ( instance == null)
        {
            instance = this;
        }   
    }

    // Updates Score Board
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        // Line for seeing exactly how many coins there are
        text.text = "x" + score.ToString();

    
    }
}
