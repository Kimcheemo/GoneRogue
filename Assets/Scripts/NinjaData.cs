using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NinjaData : MonoBehaviour
{
    public bool isAlive;
    public GameObject destroyEffect;
    Respawn respawn;
    public Animator animator;

    public Manager manager;

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        // get necessary game objects
        respawn = GameObject.Find("Manager").GetComponent<Respawn>();
        animator = GetComponent<Animator>();
        isAlive = true;
    }

    // Detect collision with Uzai
    void OnCollisionEnter2D(Collision2D collision)
    {
         OnCollision(collision.gameObject);
    }

    // do this when ninja collides with uzai
    void OnCollision(GameObject thing)
    {
        Pathfinding.AIDestinationSetter uzai = thing.GetComponent<AIDestinationSetter>();
        if (uzai != null && uzai.state == 1)
        {
            FindObjectOfType<AudioManager>().Play("Ninja Death");
            respawn.StartCoroutine(respawn.NinjaDeath(this.gameObject));
            manager.numDeadNinjas++;
        }
    }
}
