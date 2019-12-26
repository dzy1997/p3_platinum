using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuff_gundeck : debuff_controller
{
    // denote the Weapon it controls
    public Enemy_shoot es;
    // denote the time ti will get stun
    public float stun_time;

    // denote the rigidbody it controls
    private Rigidbody2D rb;
    // denote the debuff state
    private bool inStun;

    // reset
    public override void reset_state()
    {
        inStun = false;
        isStun = false;
        es.enabled = true;
    }

    private void Start()
    {
        inStun = false;
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
        es.enabled = false;
        yield return new WaitForSeconds(stun_time);
        // enable the AI and weapon
        es.enabled = true;
        inStun = false;
        isStun = false;
    }
}
