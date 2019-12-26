using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake_camera : MonoBehaviour
{
    // denote the shake radius and time
    public float duration;
    public float radius;
    // denote something it controls
    public GameObject something;
    // denote the shake effect it controls
    public ScreenShakeEffect sse;

    // denote if reached
    private bool reached;

    private void Start()
    {
        reached = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !reached)
        {
            reached = true;
            sse.Shake(duration, radius);
            if (something)
                something.SetActive(true);
        }
    }
}
