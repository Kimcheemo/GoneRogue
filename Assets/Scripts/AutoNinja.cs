using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AutoNinja : MonoBehaviour
{
    public float BASE_SPEED = 5f;
    public List<Transform> moveSpotsList;
    public Transform spots;
    public Transform[] moveSpots;
    
    int randomSpot;
    public LayerMask mask;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // put all the move spots into an array
        foreach(Transform node in spots)
        {
            moveSpotsList.Add(node);
        }
        moveSpots = moveSpotsList.ToArray();
        // randomly select a starting point
        randomSpot = 0;
    }

    // Update is called once per set time
    void FixedUpdate()
    {
        
        // check for collision
        RaycastHit2D hit = Physics2D.Linecast(transform.position, moveSpots[randomSpot].position, mask);

        // move to random 
        if(hit.collider == null)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, BASE_SPEED * Time.deltaTime);
            Animate();
            if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
            }   
        }
         // choose new random spot to try
        else
        {       
             randomSpot = Random.Range(0, moveSpots.Length);
        }
    }

    void Animate()
    {
        Vector2 movement = moveSpots[randomSpot].position - transform.position;
        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

}


