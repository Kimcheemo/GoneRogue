using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PickupGold : Pickup
{
    protected override void OnPickup(GameObject thing)
    {
        Pathfinding.AIDestinationSetter uzai = thing.GetComponent<AIDestinationSetter>();

        // destroy gold if uzai collects gold
        if (uzai != null)
        {
            // put uzai in chase mode
            uzai.StartCoroutine(uzai.chase());
            playAudio();
            // Need to add music otherwise destroy doesnt work / skips destroy
            //playMusic();
            Destroy(this.gameObject);
        }
    }

    void playAudio(){
        FindObjectOfType<AudioManager>().Play("Coin Collection");
       

    }
    
    void playMusic(){
        FindObjectOfType<AudioManager>().Play("Uzai Chase");
    }
}
