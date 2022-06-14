using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Ninja : MonoBehaviour
{
    public float BASE_SPEED = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;
    float currentSpeed;
    
  


    // Start is called before the first frame update
    void Start()
    {
        // get necessary game objects
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentSpeed = BASE_SPEED;
    }

    // Update is called once per frame
    // use for input
    void Update()
    {
        // get keygoard input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        Animate();
        
    }

    // Excuted on a timer rather than each frame
    // use for movement
    void FixedUpdate()
    {
        Move();
    }

    // move sprite
    void Move()
    {
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }

    // animate sprite
    void Animate()
    {
        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // Changes Object Speed on collision with gold coin
    public IEnumerator SpeedChange(float newSpeed, float timeInSecs)
    {
        currentSpeed = newSpeed;
        yield return new WaitForSeconds(timeInSecs);
        currentSpeed = BASE_SPEED;
    }
}
