using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_direction : MonoBehaviour
{
    // denote the direction of an object
    public Vector2 direction;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the direction of an object as downwards
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(rb.velocity);
        // self adjust its direction
        adjust_dir();
    }

    // adjust the direction of object according to its velocity
    private void adjust_dir()
    {
        if (rb != null)
        {
            if (rb.velocity.magnitude < 0.01f)
                return;
            direction = rb.velocity.normalized;
        }
    }

    // adjust the direction of object by outside methods
    public void adjust_dir(Vector2 dir)
    {
        direction = dir.normalized;
    }
}
