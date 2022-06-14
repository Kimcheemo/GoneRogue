using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Shuriken : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage;
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .6f);
        Destroy(gameObject);

		Uzai uzai = collision.gameObject.GetComponent<Uzai>();

		if(uzai != null){
            uzai.StartCoroutine(uzai.SpeedChange(uzai.baseSpeed - 2, 3f));
            uzai.StartCoroutine(uzai.Flash());
			uzai.TakeDamage(damage);
		}
    }
}
