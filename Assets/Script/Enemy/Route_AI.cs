using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route_AI : Enemy_moving_AI
{
    // this AI move with transform modification
    // need to access object_direction to indicate where it is facing

    // denote the transform it control
    public GameObject moved;

    // denote the wait time at each position
    public float wait_time;

    // denote the route AI will path through
    public List<Vector3> position;

    // denote the fixed direction the AI will facing to
    public Vector2 face_dir;

    // denote the direction it will follow to
    public Object_direction o_d;

    // denote if is in a coroutine
    private bool isInprogress;
    // denote the position AI is at
    private int pos;
    // denote the size of position list
    private int size;
    // denote the initial position
    private Vector3 init_pos;

    // Start is called before the first frame update
    void Start()
    {
        isInprogress = false;
        o_d.adjust_dir(face_dir);
        pos = 0;
        size = position.Count;
        init_pos = moved.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInprogress)
        {
            o_d.adjust_dir(face_dir);
            isInprogress = true;
            StartCoroutine(moving());
        }
    }

    // a coroutine determining the moving behavior of object
    IEnumerator moving()
    {
        Vector3 next_pos = init_pos + position[pos];
        Vector3 start_pos = moved.transform.position;

        // start transform between two positions
        float jouney_dist = Vector3.Distance(start_pos, next_pos);
        // Distance moved equals elapsed time times speed..
        float covered_dist = 0f;
        float frac = covered_dist / jouney_dist;
        while (frac < 1)
        {
            moved.transform.position = Vector3.Lerp(start_pos, next_pos, frac);
            covered_dist += Time.deltaTime * speed;
            frac = covered_dist / jouney_dist;
            yield return 0;
        }
        transform.position = Vector3.Lerp(start_pos, next_pos, 1f);

        // transform finished, stay for a while
        yield return new WaitForSeconds(wait_time);
        pos = (pos + 1) % size;

        isInprogress = false;
    }
}
