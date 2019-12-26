using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_debuff : debuff_controller
{
    // denote the laser shoot it controls
    public laser_shoot ls;

    public float stun_time;

    // denote the state
    private bool inStun;

    // reset the debuff when re-enabled
    public override void reset_state()
    {
        inStun = false;
        isStun = false;
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
        ls.Set_active_state(false);
        yield return new WaitForSeconds(stun_time);
        ls.Set_active_state(true);
        inStun = false;
        isStun = false;
    }
}
