using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator animator;
    private readonly float jump_force = 600f;
    private readonly float move_force = 10f;
    private float horizontal_move = 0;
    private bool to_jump;
    private bool on_ground = true;
    private bool prev_on_ground;
    private bool landed = false;


    public Transform ground_check;
    public float ground_check_radius;
    public LayerMask ground_layer;

    public float last_player_check_radius;
    public LayerMask last_player_layer;

    private GameObject overlap_door = null;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void ResetPlayer(Vector3 position)
    {
        this.enabled = true;
        player.transform.position = position;
    }

    private void Update()
    {
        horizontal_move = Input.GetAxisRaw("Horizontal");
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && on_ground)
            to_jump = true;

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && overlap_door != null)
            overlap_door.GetComponent<Door>().OpenDoor();
    }

    private void FixedUpdate()
    {
        FindObjectOfType<Retry>().EnqueueMove(player.transform.position, player.transform.eulerAngles);
        prev_on_ground = on_ground;
        on_ground = Physics2D.OverlapCircle(ground_check.position, ground_check_radius, ground_layer);
        if (!on_ground && !Physics2D.GetIgnoreLayerCollision(7, 8)) on_ground = Physics2D.OverlapCircle(ground_check.position, last_player_check_radius, last_player_layer);

        if (!on_ground && !animator.GetCurrentAnimatorStateInfo(0).IsName("CharacterJumpAnimation"))
            animator.Play("CharacterJumpAnimation");

        if (!prev_on_ground && on_ground) landed = true;

        switch (horizontal_move)
        {
            case -1:
                GoLeft();
                break;

            case 1:
                GoRight();
                break;

            default:
                Stop();
                break;
        }

        if (to_jump && on_ground)
            Jump();
    }

    private void Jump()
    {
        to_jump = false;
        player.velocity = jump_force * Time.deltaTime * Vector2.up;
    }

    private void GoLeft()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("CharacterJumpAnimation") || landed)
        {
            landed = false;
            animator.Play("CharacterRunningAnimation");
        }
        player.transform.eulerAngles = Vector3.up * 180;
        player.transform.position = player.transform.position + Vector3.left * move_force * Time.fixedDeltaTime;
    }

    private void GoRight()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("CharacterJumpAnimation") || landed)
        {
            landed = false;
            animator.Play("CharacterRunningAnimation");
        }
        player.transform.eulerAngles = Vector3.zero;
        player.transform.position = player.transform.position + Vector3.right * move_force * Time.fixedDeltaTime;
    }

    private void Stop()
    {
        if (on_ground)
            animator.Play("CharacterBlinkAnimation");
    }

    public bool OnGround()
    {
        return on_ground;
    }

    public bool IsMoving()
    {
        return horizontal_move != 0;
    }

    public void SetOverlapDoor(GameObject door)
    {
        overlap_door = door;
    }

    public void GameOver()
    {
        animator.Play("CharacterBlinkAnimation");
        this.enabled = false;
    }
}