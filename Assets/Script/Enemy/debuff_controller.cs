using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class debuff_controller : MonoBehaviour
{
    // denote the state of debuf of the object
    protected bool isStun = false;
    protected bool isSlow = false;

    // public method that control the state
    public void Set_stun()
    {
        isStun = true;
    }

    public void Set_slow()
    {
        isSlow = true;
    }

	public bool IsStun{
		get{
			return  isStun;
		}
	}

    public abstract void reset_state();
}
