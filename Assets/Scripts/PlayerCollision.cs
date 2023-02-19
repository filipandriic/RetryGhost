using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Water") && FindObjectOfType<GameManager>().InGame())
        {
            StartCoroutine(FindObjectOfType<GameManager>().GameOver());
        }
    }
}
