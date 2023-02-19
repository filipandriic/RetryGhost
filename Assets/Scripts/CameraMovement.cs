using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private float x_bound = 17.59f;
    private float y_bound = 9.2f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(player.transform.position.x, -x_bound, x_bound),
            Mathf.Clamp(player.transform.position.y, -y_bound, y_bound),
            -10);
    }
}
