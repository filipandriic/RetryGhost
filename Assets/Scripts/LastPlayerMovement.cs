using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public LayerMask player_layer;
    private float prev_x;

    private Queue<Vector2> positions = new Queue<Vector2>();
    private Queue<Vector3> rotations = new Queue<Vector3>();

    public void ResetPlayer(Vector3 position)
    {
        player.transform.position = position;
    }

    private void FixedUpdate()
    {
        if (positions.Count > 0)
            Move();
        else if (!OverlappingPlayer() && Physics2D.GetIgnoreLayerCollision(7, 8))
            Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    private void Move()
    {
        player.transform.position = positions.Dequeue();
        player.transform.eulerAngles = rotations.Dequeue();
    }

    private bool OverlappingPlayer()
    {
        return Physics2D.OverlapCircle(transform.position, 0.6f, player_layer);
    }

    public void ResetMovement()
    {
        positions.Clear();
        rotations.Clear();
    }

    public void EnqueuePosition(Vector2 position)
    {
        positions.Enqueue(position);
    }
    public void EnqueueRotation(Vector3 rotation)
    {
        rotations.Enqueue(rotation);
    }
}
