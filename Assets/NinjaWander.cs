using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaWander : MonoBehaviour
{
    public float BASE_SPEED = 200f;
    public Transform[] moveSpots;
    private int randomSpot;
   // public LayerMask mask;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        // randomly select a starting point
        randomSpot = 0;
    }

    // Update is called once per set time
    void FixedUpdate()
    {
        Debug.Log("going to " + randomSpot);
         // move to random 
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, BASE_SPEED * Time.deltaTime);
        Animate();
        // if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        // {
        //     randomSpot = 2;
            
        // }   
        
        
    }

    void Animate()
    {
        Vector2 movement = moveSpots[randomSpot].position - transform.position;
        if (movement != Vector2.zero)
        {
            animator.SetFloat("Direction", movement.x); 
        }
       
        Debug.Log("H: " + movement.x);
    }
}