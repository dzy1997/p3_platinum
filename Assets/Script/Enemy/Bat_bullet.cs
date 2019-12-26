using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_bullet : abstract_bullet
{
    // denote the view it controls
    public GameObject view;
    // denote the threshold for track
    public float distance;
    Rigidbody2D rb;
    bool set_progress;
    bool inshake;
    bool istrack;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        set_progress = false;
        inshake = false;
        istrack = true;
    }

    void Update()
    {
        if (isSet && !set_progress)
        {
            set_progress = true;
            rb.velocity = shoot_dir * speed;
        }
        if (set_progress && istrack)
        {
            // judge whether continue to track users
            if (!target.activeSelf)
                istrack = false;
            if ((target.transform.position - transform.position).magnitude < distance)
                istrack = false;

            Vector2 dir = (target.transform.position - transform.position).normalized;
            rb.velocity = dir * speed;
            if (!inshake)
            {
                inshake = true;
                StartCoroutine(shake());
            }
        }
    }

    IEnumerator shake()
    {
        for (int i = 1; i < 5; i++)
        {
            view.transform.localPosition = Random.onUnitSphere * 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        inshake = false;
    }
}
