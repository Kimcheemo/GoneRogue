using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDestroy : MonoBehaviour
{
    public GameObject spikesPrefab;
    public GameObject smokePrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject smoke = Instantiate(smokePrefab, firePoint.position, firePoint.rotation);
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.01f);
        GameObject smoke = Instantiate(smokePrefab, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(20f);

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    { 
    }
}
