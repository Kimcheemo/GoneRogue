using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class smokeDestroy : MonoBehaviour
{
    public GameObject smokePrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}