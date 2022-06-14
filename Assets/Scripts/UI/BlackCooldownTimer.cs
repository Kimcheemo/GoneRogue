using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class BlackCooldownTimer : MonoBehaviour
{
    //public int minimum;
    public float CooldownTime = 15;
    float current;
    float onesec;
    public Image mask;
    public Image fill;
    public Color color;

    // Grab current Score from ScoreManager
    // Using this video - https://youtu.be/oAgW1GUDhdc

    // Grab time in SwordSlash Script
    public ThrowShuriken ShurikenInfo;

    // Start is called before the first frame update
    void Start()
    {
        current = CooldownTime; // Fills Timer Color
        GetCurrentFill();
    }

    // Update is called once per frame
    void Update()
    {

        // Update Time with every frame
        ShurikenInfo = FindObjectOfType<ThrowShuriken>();
        if (ShurikenInfo.FlagTimer == true)
        {
            current = CooldownTime;
            ShurikenInfo.FlagTimer = false;
            GetCurrentFill();
        }
        if (ShurikenInfo.isAttacking)
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
        // float currentOffset = current - maximum;
        // float maximumOffset = maximum - minimum;
        float fillAmount = (float)current / (float)CooldownTime;
        fill.fillAmount = fillAmount;

        // Changes the color of the progress bar
        fill.color = color;
    }
}

