using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move_tuto : MonoBehaviour
{
    // denote the offset vector the camera will have
    public Vector3 offset;
    // denote the state of the camera
    public bool following = true, fixX = false, fixY = false, fixZ = true;
    // denote the player it follows
    public GameObject player;

    // used for moving camera
    private Vector3 velocity;

    //Whether the camera follows the player and fix on an axis
    public float fixXval, fixYval, fixZval = -10f;
    Vector3 GetAvgPos()
    {
        Vector3 avg = player.transform.position;
        return avg;
    }

    // set the state of the movement of camera
    public void SetFixXYZ(bool fixX, bool fixY, bool fixZ, float fixXval, float fixYval, float fixZval)
    {
        this.fixX = fixX;
        this.fixY = fixY;
        this.fixZ = fixZ;
        this.fixXval = fixXval;
        this.fixYval = fixYval;
        this.fixZval = fixZval;
    }

    // set the offset of the camera
    public void Setoffset(Vector3 off_s)
    {
        offset = off_s;
    }

    public void MoveToPos(Vector3 dest, float time = 2f)
    {
        StartCoroutine(MoveSchedule(dest, time));
    }
    IEnumerator MoveSchedule(Vector3 dest, float time = 2f)
    { //take time to go to target and wait in total
        while (!following)
        {
            yield return 0;
        }
        following = false;
        float timer = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.SmoothDamp(transform.position, dest, ref velocity, 0.5f);
            yield return 0;
        }
        following = true;
    }
    void Start()
    {
        velocity = Vector3.zero;
    }
    void Update()
    {
        if (following)
        {
            Vector3 target = GetAvgPos();
            if (fixZ) target.z = fixZval;
            if (fixX) target.x = fixXval;
            if (fixY) target.y = fixYval;
            transform.position = Vector3.SmoothDamp(transform.position, target + offset, ref velocity, 0.5f);
            //transform.position += (target - transform.position) * 0.1f;
        }
    }
}
