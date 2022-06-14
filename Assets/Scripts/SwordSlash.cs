using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlash : MonoBehaviour
{
    public Animator animator;
    float attackTime = .25f;
    float attackCounter = .25f;
    public bool isAttacking;
    public Transform firePoint;
    float dirX, dirY, rotateAngle;
    public bool FlagTimer;

    // Cooldown time for next attack variables
    float cooldownTime = 15;
    public float nextFireTime = 0;

    public int damage;

    void Start()
    {
        animator.SetBool("isAttacking", false);
        FlagTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        // get x and y components of direction from input
        dirX = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        dirY = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
        // rotate the firepoint
        Rotate();
        // Slash Grass / Uzai
        // TBA
        // animate the sprite
        Animate();

        // update the damage value
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Weapon"))
        {
            obj.GetComponent<Sword>().damage = damage;
        }
    }

    //animate the Red ninja when they are attacking
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

        //Check to see if Attack time is avalible
        if (Time.time > nextFireTime)
        {
            if (Input.GetButtonDown("Ability"))
            {
                attackCounter = attackTime;
                animator.SetBool("isAttacking", true);
                isAttacking = true;

                // Set next avalibility of attack time
                nextFireTime = Time.time + cooldownTime;
                //print("Red ninja: cooldown started");
                FindObjectOfType<AudioManager>().Play("Sword Slash"); 
                
            }

        }
        else{
           if (Input.GetButtonDown("Ability"))
            {
                FindObjectOfType<AudioManager>().Play("Ability Disabled");
            }
        }

    }

    void Rotate()
    {
        // up 
        if (dirX == 0 && dirY == 1)
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

       // firePoint.rotation = Quaternion.Euler(0f, 0f, rotateAngle);
    }
}
