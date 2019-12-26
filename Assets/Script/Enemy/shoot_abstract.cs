using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class shoot_abstract : MonoBehaviour
{
    // denote the direction it will shoot the bullet
    public Vector3 shoot_direction;

    // reset the state
    public abstract void reset_state();
}
