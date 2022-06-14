using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class CooldownTimer : MonoBehaviour
{
    //public int minimum;
    public float CooldownTime = 20;
    float current;
    float onesec;
    public Image mask;
    public Image fill;
    public Color color;

    // Grab current Score from ScoreManager
    // Using this video - https://youtu.be/oAgW1GUDhdc

    // Grab time in SwordSlash Script
    public SwordSlash SwordInfo;

    // Start is called before the first frame update
    void Start()
    {
        current = CooldownTime; // Fills the timer color
        GetCurrentFill();
    }

    // Update is called once per frame
    void Update()
    {

        // Update Time with every frame
        SwordInfo = FindObjectOfType<SwordSlash>();
        if (SwordInfo.isAttacking)
        {
            // Sets Timer to zero to show can't use
            current = 0;
            // Finds the next second
            onesec = Time.time + 1;
            GetCurrentFill();
        }
        if ((onesec < Time.time) && (current < CooldownTime))
        {
            onesec = Time.time + 1;
            current++;
            GetCurrentFill();
        }
        else;

    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)CooldownTime;
        fill.fillAmount = fillAmount;

        // Changes the color of the progress bar
        fill.color = color;
    }
}
