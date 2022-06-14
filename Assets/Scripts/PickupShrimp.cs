using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PickupShrimp : Pickup
{
    public AudioSource audioSource;
    public AudioClip bonus;
    public float volume = .5f;

    protected override void OnPickup(GameObject thing)
    {  
        Ninja ninja = thing.GetComponent<Ninja>();
        AutoNinja automatedNinja = thing.GetComponent<AutoNinja>();
        // destroy and speed up if ninja collects shrimp AND is not automated
        if (ninja != null && automatedNinja.GetComponent<AutoNinja>().enabled != true)
        { 
            ninja.StartCoroutine(ninja.SpeedChange(10f, 3f));
            FindObjectOfType<AudioManager>().Play("Sushi");
            // check ninja color and recharge ability
            if (ninja.name == "BlackNinja")
            {
                thing.GetComponent<ThrowShuriken>().nextFireTime  = Time.time;
                thing.GetComponent<ThrowShuriken>().FlagTimer = true;
            }
            if (ninja.name == "RedNinja")
            {
                thing.GetComponent<SwordSlash>().nextFireTime  = Time.time;
                thing.GetComponent<SwordSlash>().FlagTimer = true;
            }
            if (ninja.name == "GreenNinja")
            {
                thing.GetComponent<SpikesAppear>().nextFireTime  = Time.time;
                thing.GetComponent<SpikesAppear>().FlagTimer = true;
            }
            Destroy(this.gameObject);
            
        }
    }
}
