using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage;
    void OnCollisionEnter2D(Collision2D collision)
    {

        Uzai uzai = collision.gameObject.GetComponent<Uzai>();
        if (uzai != null)
        {
            uzai.StartCoroutine(uzai.SpeedChange(uzai.baseSpeed - 2, 3f));
            uzai.StartCoroutine(uzai.Flash());
            uzai.TakeDamage(damage);
        }
    }
}
