using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjust_Aim : MonoBehaviour
{
    // denote which aim it will adjust to
    public Object_direction aim;
    // denote the current direction
    public Vector2 cur_dir;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the current direction as downwards
        cur_dir = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        check_change_dir();
    }

    // check if need to change current direction
    // if need to change, change the current direction
    private void check_change_dir()
    {
        Vector2 aim_dir = aim.direction;
        if (aim_dir.x < 0 && aim_dir.y < 0)
            aim_dir = new Vector2(-1, -1);
        else if (aim_dir.x < 0 && aim_dir.y > 0)
            aim_dir = new Vector2(-1, 1);
        else if (aim_dir.x > 0 && aim_dir.y < 0)
            aim_dir = new Vector2(1, -1);
        else if (aim_dir.x > 0 && aim_dir.y > 0)
            aim_dir = new Vector2(1, 1);
        aim_dir = aim_dir.normalized;

        if (aim_dir != cur_dir)
            rotate_aim(aim_dir);
    }

    // rotate the object to current direction
    private void rotate_aim(Vector2 aim_dir)
    {
        cur_dir = aim_dir;
        if (aim_dir == Vector2.down)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (aim_dir == Vector2.up)
            transform.eulerAngles = new Vector3(0, 0, 180);
        else if (aim_dir == Vector2.left)
            transform.eulerAngles = new Vector3(0, 0, -90);
        else if (aim_dir == Vector2.right)
            transform.eulerAngles = new Vector3(0, 0, 90);
        else if (aim_dir.x < 0 && aim_dir.y < 0)
            transform.eulerAngles = new Vector3(0, 0, -45);
        else if (aim_dir.x < 0 && aim_dir.y > 0)
            transform.eulerAngles = new Vector3(0, 0, -135);
        else if (aim_dir.x > 0 && aim_dir.y < 0)
            transform.eulerAngles = new Vector3(0, 0, 45);
        else if (aim_dir.x > 0 && aim_dir.y > 0)
            transform.eulerAngles = new Vector3(0, 0, 135);
    }
}
