using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float RESPAWN_TIME = 16f;
    public Transform spawnPoint;
    public GameObject destroyEffect;
    public GameObject respawnEffect;
    public Manager manager;

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    public IEnumerator NinjaDeath(GameObject ninja)
    {
        // ninja death hapens in NinjaController script
        ninja.GetComponent<NinjaData>().isAlive = false;
        ninja.GetComponent<Animator>().SetBool("isDead", true);
              
        // wait two seconds before destorying object
        yield return new WaitForSeconds(1);
        //play destroy animation 
        GameObject dEffect = Instantiate(destroyEffect, ninja.GetComponent<Transform>().position, Quaternion.identity);
        // call respawn function
        StartCoroutine(respawnNinja(ninja));
        // destroy effect and make ninja disappear 
        Destroy(dEffect, .6f);
        ninja.GetComponent<SpriteRenderer>().enabled = false;
    }

    public IEnumerator respawnNinja(GameObject ninja)
    {
        // move ninja off map
        ninja.transform.position = new Vector3(-100, 100, 100);
        // wait for 20 seconds before respawning
        yield return new WaitForSeconds(RESPAWN_TIME);
        //move ninja to respawn spot
        ninja.transform.position = spawnPoint.position;
        // make ninja live 
        ninja.GetComponent<Animator>().SetBool("isDead", false);
        //play respawn effect
        GameObject rEffect = Instantiate(respawnEffect, ninja.GetComponent<Transform>().position, Quaternion.identity);
        // destroy effect and make ninja appear 
        Destroy(rEffect, .6f);
       
        // make ninja stand still before moving
        ninja.GetComponent<Animator>().SetBool("isAttacking", false);
        ninja.GetComponent<Animator>().SetFloat("Horizontal", 0);
        ninja.GetComponent<Animator>().SetFloat("Vertical", -1);
        ninja.GetComponent<Animator>().SetFloat("Speed", 0);
        ninja.GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(1);
        ninja.GetComponent<SpriteRenderer>().enabled = true;
        ninja.GetComponent<CapsuleCollider2D>().enabled  = true;
        ninja.GetComponent<AutoNinja>().enabled = true;
        ninja.GetComponent<NinjaData>().isAlive = true;
        manager.numDeadNinjas--;
    }
}
