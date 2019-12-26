using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_anim_control : MonoBehaviour
{
    // denote the direction it sees
    public Route_AI ra;

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
        if (ra.face_dir == Vector2.down)
            anim.SetInteger("direction", 0);
        else if (ra.face_dir == Vector2.up)
            anim.SetInteger("direction", 1);
        else if (ra.face_dir == Vector2.right)
            anim.SetInteger("direction", 2);
        else if (ra.face_dir == Vector2.left)
            anim.SetInteger("direction", 3);
    }
}
