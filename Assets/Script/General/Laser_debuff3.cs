using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_debuff3 : debuff_controller
{
    public float stun_time;
    public Laser_degree lr;

    // denote the state
    private bool inStun;

    // reset when called
    public override void reset_state()
    {
        inStun = false;
        isStun = false;
        lr.Set_active_state(true);
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

    // handle the stun hebaviour
    IEnumerator Stun_routine()
    {
        lr.Set_active_state(false);
        yield return new WaitForSeconds(stun_time);
        lr.Set_active_state(true);
        inStun = false;
        isStun = false;
    }
}
