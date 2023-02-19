using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    private float start_x;
    private float start_y;
    public bool go_right;
    public bool go_up;
    public float speed;
    private Rigidbody2D player;
    private bool player_on;

    private void Start()
    {
        start_x = transform.position.x;
        start_y = transform.position.y;
        player_on = false;
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (horizontal > 0) HorizontalMove();
        if (vertical > 0) VerticalMove();
    }

    private void HorizontalMove()
    {
        if (go_right)
        {
            if (player_on) player.transform.position = player.transform.position + Vector3.right * Time.fixedDeltaTime * speed;
            transform.position = transform.position + Vector3.right * Time.fixedDeltaTime * speed;
        }
        else
        {
            if (player_on) player.transform.position = player.transform.position + Vector3.left * Time.fixedDeltaTime * speed;
            transform.position = transform.position + Vector3.left * Time.fixedDeltaTime * speed;
        }

        if (go_right && transform.position.x - start_x > horizontal)
            go_right = false;
        else if (!go_right && start_x - transform.position.x > horizontal)
            go_right = true;
    }

    private void VerticalMove()
    {
        if (go_up)
        {
            if (player_on) player.transform.position = player.transform.position + Vector3.up * Time.fixedDeltaTime * speed;
            transform.position = transform.position + Vector3.up * Time.fixedDeltaTime * speed;
        }
        else
        {
            if (player_on) player.transform.position = player.transform.position + Vector3.down * Time.fixedDeltaTime * speed;
            transform.position = transform.position + Vector3.down * Time.fixedDeltaTime * speed;
        }

        if (go_up && transform.position.y - start_y > vertical)
            go_up = false;
        else if (!go_up && start_y - transform.position.y > vertical)
            go_up = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
            player_on = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
            player_on = false;
    }
}
