using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_AI : Enemy_moving_AI
{
    // denote if it is in a turning coroutine
    private bool isInprogress;

    private void Start()
    {
        isInprogress = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInprogress)
        {
            isInprogress = true;
            StartCoroutine(moving());
        }
    }

    // a coroutine determining the moving behavior of object
    IEnumerator moving()
    {
        // denote how long it will change the direction
        Vector2 dir = Take_random_turn();
        rb.velocity = dir * speed;
        float t = 3;
        while (t > 0)
        {
            t = t - Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        isInprogress = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Border"))
            rb.velocity = -rb.velocity;
    }
}
