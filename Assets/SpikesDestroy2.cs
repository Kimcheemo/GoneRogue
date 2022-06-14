using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDestroy2 : MonoBehaviour
{
    public GameObject spikesPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(20f);

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
