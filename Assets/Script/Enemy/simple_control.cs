using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// just for test case
public class simple_control : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public float speed;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up))
            rb.velocity = Vector3.up * speed;
        else if (Input.GetKey(down))
            rb.velocity = Vector3.down * speed;
        else if (Input.GetKey(left))
            rb.velocity = Vector3.left * speed;
        else if (Input.GetKey(right))
            rb.velocity = Vector3.right * speed;
        else
            rb.velocity = Vector3.zero;
    }


}
