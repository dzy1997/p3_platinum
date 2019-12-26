using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abstract_bullet : MonoBehaviour
{
    // denote whether the bullet is ready to use
    protected bool isSet;
    // set the bullet state when it is ok
    public void Set_ready()
    {
        isSet = true;
    }

    // denote the speed of bullet
    protected float speed;
    // set the speed ot the bullet
    public void set_speed(float s)
    {
        speed = s;
    }

    // denote the target of bullet
    protected GameObject target;
    // set the target of the bullet
    public void set_target(GameObject t)
    {
        target = t;
    }

    // denote the direction bullet is shot
    protected Vector2 shoot_dir;
    // set the direction of the shooting
    public void set_shotdir(Vector2 dir)
    {
        shoot_dir = dir;
    }
}
