using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    //private float mace_force = 500f;
    private Rigidbody2D mace;
    //private float near_stop = 0.01f;
    private Vector2 direction;

    private void Start()
    {
        mace = GetComponent<Rigidbody2D>();
        direction = Vector2.left;

    }

    private void FixedUpdate()
    {
        
    }

    private void ChangeDirection()
    {
        if (direction == Vector2.left)
            direction = Vector2.right;
        else
            direction = Vector2.left;
    }
}
