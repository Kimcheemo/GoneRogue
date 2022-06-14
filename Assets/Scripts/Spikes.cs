using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Spikes : MonoBehaviour
{
    public GameObject spikesPrefab;
    public GameObject spikes2Prefab;
    public GameObject smokePrefab;
    public Transform firePoint;
    public int collides = 0;
    public int damage;



    void OnCollisionEnter2D(Collision2D collision)
    {
        collides = 1;

        Uzai uzai = collision.gameObject.GetComponent<Uzai>();

        if (uzai != null)
        {
            uzai.StartCoroutine(uzai.SpeedChange(0f, 5f));
            uzai.StartCoroutine(uzai.Flash());
            uzai.TakeDamage(damage);
            StartCoroutine(Disappear());
        }
        else
        {
            Destroy(gameObject);
            GameObject spikes2 = Instantiate(spikes2Prefab, GameObject.Find("GreenNinja").transform.position, GameObject.Find("GreenNinja").transform.rotation);
            Rigidbody2D rb = spikes2.GetComponent<Rigidbody2D>();

        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5f);

        Destroy(this.gameObject);
    }


}

