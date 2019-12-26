using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_bullet : abstract_bullet
{
    private Rigidbody2D rb;
    private bool set_progress;
    private Object_direction od;
    public int collide_time = 5;
    private bool is_bounce;

    // denote the audio of reflection
    public AudioClip reflect;
    // denote the color it will changes
    public Color color;
    // denote the sprite
    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        set_progress = false;
        od = GetComponent<Object_direction>();
        is_bounce = false;
    }

    void Update()
    {
        if (isSet && !set_progress)
        {
            set_progress = true;
            rb.velocity = shoot_dir * speed;
        }
        if (collide_time <= 0)
        {
            GetComponent<ExplosionParticleGenerator>().Launch();
            Destroy(gameObject);
        }
    }

    IEnumerator bounce_wall()
    {
        AudioSource.PlayClipAtPoint(reflect, transform.position, 2f);
        yield return 0;
        shoot_dir = od.direction;
        collide_time = collide_time - 1;
        set_progress = false;
        is_bounce = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!is_bounce)
        {
            Debug.Log(collision.gameObject.name);
            is_bounce = true;
            StartCoroutine(bounce_wall());
            if (collision.gameObject.CompareTag("Player"))
            {
                GetComponent<SpriteRenderer>().sprite = sprite;
                GetComponent<SpriteRenderer>().color = color;
                GetComponent<bounce_damage>().damage_target.Add("Boss");
                gameObject.layer = LayerMask.NameToLayer("Player_bullet");
            }
        }
    }
}
