using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSilver : Pickup
{
	public bool active;

	void Start()
	{
		active = true;
	}

    protected override void OnPickup(GameObject thing)
    {
        // check if the thing that colided with the coin is Uzai, if so, destroy
        if (thing ==  GameObject.FindWithTag("Uzai"))
        {
			active = false;
            Destroy(this.gameObject);
		
        }
        
    }

	

}
