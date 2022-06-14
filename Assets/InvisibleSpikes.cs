using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class InvisibleSpikes : MonoBehaviour
{
    public GameObject invisSpikesPrefab;
    //public int damage;
    void OnCollisionEnter2D(Collision2D collision)
    {

        Uzai uzai = collision.gameObject.GetComponent<Uzai>();

        if (uzai != null)
        {
            StartCoroutine(Disappear());
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }


}
