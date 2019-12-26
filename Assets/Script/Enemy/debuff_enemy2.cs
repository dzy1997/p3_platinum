using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuff_enemy2 : debuff_controller
{
    // denote the AI it controls
    public GameObject AI_controlled;
    // denote the Weapon it controls
    public GameObject weapon;
    // denote the time ti will get stun
    public float stun_time;
    // denote the debuff state
    private bool inStun;
    private bool inSlow;

    // denote the rigidbody it controls
    private Rigidbody2D rb;

    // reset
    public override void reset_state()
    {
        inStun = false;
        inSlow = false;
        isStun = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inStun = false;
        inSlow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStun && !inStun)
        {
            inStun = true;
            StartCoroutine(Stun_routine());
        }
    }

    // handle the stuck routine
    IEnumerator Stun_routine()
    {
        // disable the AI and weapon
        Enemy_moving_AI ai = AI_controlled.GetComponent<Enemy_moving_AI>();
        Enemy_shoot es = weapon.GetComponent<Enemy_shoot>();
        float temp = ai.speed;
        es.enabled = false;
        ai.enabled = false;
        ai.speed = 0f;
        yield return new WaitForSeconds(stun_time);
        // enable the AI and weapon
        ai.enabled = true;
        ai.speed = temp;
        es.enabled = true;
        inStun = false;
        isStun = false;
    }
}
