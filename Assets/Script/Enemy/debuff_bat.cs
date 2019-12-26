using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuff_bat : debuff_controller
{
    // Update is called once per frame
    void Update()
    {
        if (isStun)
        {
            GetComponent<Health>().ChangeHealthByAmount(-3);
        }
    }

    // reset
    public override void reset_state()
    {
        isStun = false;
    }
}
