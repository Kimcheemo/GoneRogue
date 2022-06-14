using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowShuriken : MonoBehaviour
{
    public Animator animator;
    float attackTime = .25f;
    float attackCounter = .25f;
    public bool isAttacking;
    public Transform firePoint;
    public GameObject shurikenPrefab;
    public float shurikenForce = 12f;
    float dirX, dirY, rotateAngle;
    float cooldownTime = 15;
    public float nextFireTime = 0;
    bool abilityDisabled;
    public bool FlagTimer;

    public int damage;


    void Start()
    {
        abilityDisabled = false;
        FlagTimer = false;
        animator = this.GetComponent<Animator>();
        animator.SetBool("isAttacking", false);
    }

    // Update is called once per frame
    void Update()
    {
        // get x and y components of direction from input
        dirX = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        dirY = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
        // rotate the firepoint
        Rotate();
        // throw shuriken
        Throw();
        // animate the sprite
        Animate();

        // update the damage value
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Weapon"))
        {
            obj.GetComponent<Shuriken>().damage = damage;
        }
        
    }

    void Throw()
    {
       if(Time.time > nextFireTime)
       {
            abilityDisabled = false;
            if (Input.GetButtonDown("Ability"))
            {
                
                // crate a shuriken and give it a position
                GameObject shuriken = Instantiate(shurikenPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = shuriken.GetComponent<Rigidbody2D>();
                // throw the shuriken and play audio
                FindObjectOfType<AudioManager>().Play("Throw Shuriken");
                rb.AddForce(firePoint.up * shurikenForce, ForceMode2D.Impulse);
                // cool down
                nextFireTime = Time.time + cooldownTime;
            }
       }
       else{
            abilityDisabled = true;
            if (Input.GetButtonDown("Ability"))
            {
                FindObjectOfType<AudioManager>().Play("Ability Disabled");
            }
           
        }
    }

    //animate the black ninja when they are attacking
    void Animate()
    {
        // if T is pressed, play the attack animation
        if (isAttacking)
        {
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }
        if (Input.GetButtonDown("Ability") && !abilityDisabled)
        {
            attackCounter = attackTime;
            animator.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

    void Rotate()
    {
        // up 
        if(dirX == 0 && dirY == 1)
        {
            rotateAngle = 0;
        }
        //down
        if (dirX == 0 && dirY == -1)
        {
            rotateAngle = -180f;
        }
        //right
        if (dirX == 1 && dirY == 0)
        {
            rotateAngle = -90f;
        }
        //left
        if (dirX == -1 && dirY == 0)
        {
            rotateAngle = 90f;
        }

        firePoint.rotation = Quaternion.Euler(0f, 0f, rotateAngle);
    }
}