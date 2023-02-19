using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{
    public GameObject player;
    public GameObject last_player;
    public Button retry_button;

    public GameObject following_enemy;
    private Vector3 following_enemy_start_position;
    private Vector3 player_start_position;

    private void Start()
    {
        player_start_position = player.transform.position;
        if (following_enemy != null)
            following_enemy_start_position = following_enemy.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RetryGame();
    }

    public void EnableButton()
    {
        retry_button.enabled = true;
    }

    public void DisableButton()
    {
        retry_button.enabled = false;
    }

    public void RetryGame(bool game_over = false)
    {
        if (!game_over && !FindObjectOfType<PlayerMovement>().OnGround() && !FindObjectOfType<PlayerMovement>().IsMoving()) return;

        FindObjectOfType<PlayerMovement>().ResetPlayer(player_start_position);
        last_player.GetComponent<LastPlayerMovement>().ResetPlayer(player_start_position);
        if (following_enemy != null)
            following_enemy.transform.position = following_enemy_start_position;

        if (game_over || last_player.activeSelf)
        {
            last_player.SetActive(false);
            ResetLastPlayer();
            return;
        }

        last_player.SetActive(!last_player.activeSelf);
        Physics2D.IgnoreLayerCollision(7, 8, true);
    }

    public void SetRespawnPoint(Vector2 pos)
    {
        player_start_position.x = pos.x;
        player_start_position.y = pos.y;
    }
    public void EnqueueMove(Vector2 position, Vector3 rotation)
    {
        if (!last_player.activeSelf)
        {
            last_player.GetComponent<LastPlayerMovement>().EnqueuePosition(position);
            last_player.GetComponent<LastPlayerMovement>().EnqueueRotation(rotation);
        }
    }

    public void ResetLastPlayer()
    {
        last_player.GetComponent<LastPlayerMovement>().ResetMovement();
    }
}
