using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public GameObject blackNinja;
    public GameObject redNinja;
    public GameObject greenNinja;

    // Start is called before the first frame update
    void Start()
    {
        // disable movment for all ninjas but black upon start 
        // when the AI is done we will add enabling of AI scripts for ninjas that 
        // are not moving
        blackNinja.GetComponent<Ninja>().enabled = true;
        blackNinja.GetComponent<AutoNinja>().enabled = false;
        blackNinja.GetComponent<ThrowShuriken>().enabled = true;

        redNinja.GetComponent<Ninja>().enabled = false;
        redNinja.GetComponent<AutoNinja>().enabled = true;
        redNinja.GetComponent<SwordSlash>().enabled = false;

        greenNinja.GetComponent<Ninja>().enabled = false;
        greenNinja.GetComponent<AutoNinja>().enabled = true;
        greenNinja.GetComponent<SpikesAppear>().enabled = false;

        Debug.Log("Starting");
    }

    // Update is called once per frame
    void Update()
    {   
        // enable back
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1 was pressed");
            blackNinja.GetComponent<Ninja>().enabled = true;
            blackNinja.GetComponent<AutoNinja>().enabled = false;
            blackNinja.GetComponent<ThrowShuriken>().enabled = true;

            redNinja.GetComponent<Ninja>().enabled = false;
            redNinja.GetComponent<AutoNinja>().enabled = true;
            redNinja.GetComponent<SwordSlash>().enabled = false;

            greenNinja.GetComponent<Ninja>().enabled = false;
            greenNinja.GetComponent<AutoNinja>().enabled = true;
            greenNinja.GetComponent<SpikesAppear>().enabled = false;
        }
        // enable red
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2 was pressed");
            blackNinja.GetComponent<Ninja>().enabled = false;
            blackNinja.GetComponent<ThrowShuriken>().enabled = false;
            blackNinja.GetComponent<AutoNinja>().enabled = true;

            redNinja.GetComponent<Ninja>().enabled = true;
            redNinja.GetComponent<AutoNinja>().enabled = false;
            redNinja.GetComponent<SwordSlash>().enabled = true;

            greenNinja.GetComponent<Ninja>().enabled = false;
            greenNinja.GetComponent<AutoNinja>().enabled = true;
            greenNinja.GetComponent<SpikesAppear>().enabled = false;
        }
        // enable green
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3 was pressed");
            blackNinja.GetComponent<Ninja>().enabled = false;
            blackNinja.GetComponent<ThrowShuriken>().enabled = false;
            blackNinja.GetComponent<AutoNinja>().enabled = true;

            redNinja.GetComponent<Ninja>().enabled = false;
            redNinja.GetComponent<AutoNinja>().enabled = true;
            redNinja.GetComponent<SwordSlash>().enabled = false;

            greenNinja.GetComponent<Ninja>().enabled = true;
            greenNinja.GetComponent<AutoNinja>().enabled = false;
            greenNinja.GetComponent<SpikesAppear>().enabled = true;
        }
    }
}
