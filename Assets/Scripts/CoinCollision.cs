using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    private bool collected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !collected && FindObjectOfType<GameManager>().InGame())
        {
            collected = true;
            Destroy(transform.gameObject);
            FindObjectOfType<GameManager>().CollectCoin();
        }
    }
}
