using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff_machinegun : debuff_controller
{
    // denote the Weapon it controls
    public degree_shoot ds;
    // denote the time ti will get stun
    public float stun_time;

    // denote the debuff state
    private bool inStun;

    // reset
    public override void reset_state()
    {
        inStun = false;
        isStun = false;
        ds.enabled = true;
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
        float temp = ds.shoot_time;
        ds.shoot_time = 10000f;
        ds.enabled = false;
        yield return new WaitForSeconds(stun_time);
        // enable the AI and weapon
        ds.enabled = true;
        ds.reset_state();
        ds.shoot_time = temp;
        inStun = false;
        isStun = false;
    }
}
