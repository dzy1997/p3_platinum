using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_state : MonoBehaviour
{
    // denote the shoot abstract it controls
    public shoot_abstract s_a;
    // denote the debug controller
    public debuff_controller d_c;

    // reset the state
    public void reset_state()
    {
        s_a.reset_state();
        d_c.reset_state();
    }
}
