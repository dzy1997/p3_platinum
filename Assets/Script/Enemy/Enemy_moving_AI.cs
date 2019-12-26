using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy_moving_AI : MonoBehaviour
{
    // denote the speed it will move with
    public float speed;

    public Rigidbody2D rb;

    // generate a random direction among 8 choices
    private Vector2 generate_direction()
    {
        int choice = Random.Range(0, 8);
        if (choice == 0)
            return Vector2.up;
        if (choice == 1)
            return Vector2.down;
        if (choice == 2)
            return Vector2.left;
        if (choice == 3)
            return Vector2.right;
        if (choice == 4)
            return new Vector2(1, 1).normalized;
        if (choice == 5)
            return new Vector2(1, -1).normalized;
        if (choice == 6)
            return new Vector2(-1, 1).normalized;
        if (choice == 7)
            return new Vector2(-1, -1).normalized;
        return Vector2.down;
    }

    public Vector2 Take_random_turn()
    {
        return generate_direction();
    }
}
