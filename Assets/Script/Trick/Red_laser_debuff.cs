using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_laser_debuff : debuff_controller
{
    public float stun_time;

    // denote the state
    private bool inStun;

    // reset
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
        GetComponent<Red_laser>().Set_active_state(false);
        yield return new WaitForSeconds(stun_time);
        GetComponent<Red_laser>().Set_active_state(true);
        inStun = false;
        isStun = false;
    }
}
