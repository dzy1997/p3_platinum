using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naive_bullet : abstract_bullet
{
    Rigidbody2D rb;
    bool set_progress;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        set_progress = false;
    }

    void Update()
    {
        if (isSet && !set_progress)
        {
            set_progress = true;
            rb.velocity = shoot_dir * speed;
        }
    }
}
