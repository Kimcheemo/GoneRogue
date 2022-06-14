using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGoldCoin : MonoBehaviour
{
    public int coinValue = 5;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Uzai"))
        {
            ScoreManager.instance.ChangeScore(coinValue);
        }
    }
}
