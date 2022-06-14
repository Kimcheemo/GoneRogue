using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSilverCoin : MonoBehaviour
{
    public int coinValue = 1;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Uzai"))
        {
            ScoreManager.instance.ChangeScore(coinValue);
        }
    }
}
