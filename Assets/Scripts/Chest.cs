using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class Chest : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator animator;
    private bool chest_closed;
    private float distance = 5f;
    private float coin_x = -0.75f;
    public GameObject coin;
    private int coin_number;
    private int sorting_order = 3;
    private float coin_distance;
    public GameObject following_enemy;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        chest_closed = true;
        coin_number = 0;
        coin_distance = 1.5f / (FindObjectOfType<LevelManager>().GetNeededCoins() - 1);
    }


    void FixedUpdate()
    {
        if (chest_closed && Vector2.Distance(transform.parent.position, player.transform.position) < distance && FindObjectOfType<GameManager>().InGame())
        {
            animator.Play("ChestOpenAnimation");
        } else if (!chest_closed && Vector2.Distance(transform.parent.position, player.transform.position) >= distance)
        {
            animator.Play("ChestCloseAnimation");
        }
    }

    public void ChestOpened()
    {
        chest_closed = false;
        PutCoinsToChest(FindObjectOfType<GameManager>().GetCoinNumber());
        if (following_enemy != null)
            following_enemy.GetComponent<AIPath>().canMove = true;
    }
    public void ChestClosed()
    {
        chest_closed = true;
    }

    public void PutCoinsToChest(int num)
    {
        for (int i = 0; i < num; i++)
            PutCoinInChest();
    }

    private void PutCoinInChest()
    {
        GameObject coin_instance = Instantiate(coin, transform.parent) as GameObject;
        coin_instance.transform.localPosition = new Vector3(coin_x, -1.5f, 0f);
        coin_instance.GetComponent<SpriteRenderer>().sortingOrder = sorting_order++;
        coin_x += coin_distance;
        coin_number++;
        FindObjectOfType<LevelManager>().Unlock();
        FindObjectOfType<GameManager>().PutCoinInChest();
    }

    public int GetCoinNumber()
    {
        return coin_number;
    }
}
