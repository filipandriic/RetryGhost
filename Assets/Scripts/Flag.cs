using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && FindObjectOfType<GameManager>().InGame())
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            FindObjectOfType<GameManager>().SetRespawnPoint(transform.position.x - 0.75f, transform.position.y - 0.8f);
            //FindObjectOfType<Retry>().ResetLastPlayer();
        }
    }
}
