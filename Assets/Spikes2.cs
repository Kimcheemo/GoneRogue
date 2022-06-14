using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Spikes2 : MonoBehaviour
{
    public GameObject spikesPrefab;
    public GameObject smokePrefab;
    public Transform firePoint;
    public int damage;

    void Start()
    {
        GameObject smoke = Instantiate(smokePrefab, firePoint.position, firePoint.rotation);
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        Uzai uzai = collision.gameObject.GetComponent<Uzai>();

        if (uzai != null)
        {
            uzai.StartCoroutine(uzai.SpeedChange(0f, 5f));
            uzai.StartCoroutine(uzai.Flash());
            uzai.TakeDamage(damage);
            StartCoroutine(Disappear());
        }

    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5f);

        Destroy(this.gameObject);
    }


}

