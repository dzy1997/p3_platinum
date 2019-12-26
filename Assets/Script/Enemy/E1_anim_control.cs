using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_anim_control : MonoBehaviour
{
    // denote the direction it sees
    public Object_direction od;

    // denote the animator it controls
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = od.direction;
        if (dir == Vector2.down)
            anim.SetInteger("dir", 0);
        else if (dir == Vector2.up)
            anim.SetInteger("dir", 1);
        else if (dir == Vector2.right)
            anim.SetInteger("dir", 2);
        else if (dir == Vector2.left)
            anim.SetInteger("dir", 3);
        else if (dir.x < 0 && dir.y > 0)
            anim.SetInteger("dir", 4);
        else if (dir.x > 0 && dir.y > 0)
            anim.SetInteger("dir", 5);
        else if (dir.x < 0 && dir.y < 0)
            anim.SetInteger("dir", 6);
        else if (dir.x > 0 && dir.y < 0)
            anim.SetInteger("dir", 7);
    }
}
