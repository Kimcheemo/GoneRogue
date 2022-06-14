  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpikesAppear : MonoBehaviour
{
    public Animator animator;
    float attackTime = .25f;
    float attackCounter = .25f;
    public bool isAttacking;
    public Transform firePoint;
    public GameObject spikesPrefab;
    public GameObject smokePrefab;
    public Vector3 spikesOffset;
    public Vector3 smokeOffset;
    float dirX, dirY, rotateAngle;
    float cooldownTime = 15;
    public float nextFireTime = 0;
    public int damage;
    bool abilityDisabled;
    public bool FlagTimer;

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
        dirX = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        dirY = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        Rotate();
        Place();
        Animate();

        // update the damage value
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Weapon"))
        {
            obj.GetComponent<Spikes>().damage = damage;
        }
    }


    void Place()
    {
        if (Time.time > nextFireTime)
        {
            abilityDisabled = false;
            if (Input.GetButtonDown("Ability"))
            {
                // create spikes and give it a position
                //GameObject smoke = Instantiate(smokePrefab, firePoint.position + smokeOffset, firePoint.rotation);
                GameObject spikes = Instantiate(spikesPrefab, firePoint.position + spikesOffset, firePoint.rotation);
                Rigidbody2D rb = spikes.GetComponent<Rigidbody2D>();
                FindObjectOfType<AudioManager>().Play("Spikes");
                // cool down
                nextFireTime = Time.time + cooldownTime;
            }
        }
        else
        {
            abilityDisabled = true;
            if (Input.GetButtonDown("Ability"))
            {
                FindObjectOfType<AudioManager>().Play("Ability Disabled");
            }

        }
    }

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
        if (dirX == 0 && dirY == 1)
        {
            //rotateAngle = 0;
            spikesOffset = new Vector3(0, 1, 0);
            smokeOffset = new Vector3(0, 0.8f, 0);
        }
        //down
        if (dirX == 0 && dirY == -1)
        {
            //rotateAngle = -180f;
            spikesOffset = new Vector3(0, -1, 0);
            smokeOffset = new Vector3(0, -1.2f, 0);
        }
        //right
        if (dirX == 1 && dirY == 0)
        {
            //rotateAngle = -90f;
            spikesOffset = new Vector3(1, 0, 0);
            smokeOffset = new Vector3(1, -0.2f, 0);
        }
        //left
        if (dirX == -1 && dirY == 0)
        {
            //rotateAngle = 90f;
            spikesOffset = new Vector3(-1, 0, 0);
            smokeOffset = new Vector3(-1, -0.2f, 0);
        }
    }
}