using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_minor_check : MonoBehaviour
{
    // Start is called before the first frame update
    public bool reached = false;
    public bool fixX = false, fixY = false, fixZ = true;
    public float fixXval, fixYval, fixZval = -10f;
    public bool special_look;
    public Vector3 camDest = Vector3.zero;
    public Vector3 offset_cam = Vector3.zero;

    private bool first_reached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            set_cam();
            if (!first_reached)
                first_reached = true;
        }     
    }

    // set the camera
    private void set_cam()
    {
        Debug.Log("cam ckpt reached by player");
        CameraMove cammove = Camera.main.GetComponent<CameraMove>();
        if (special_look && !reached)
        {
            reached = true;
            cammove.MoveToPos(camDest);
        }
        cammove.SetFixXYZ(fixX, fixY, fixZ, fixXval, fixYval, fixZval);
        cammove.Setoffset(offset_cam);
    }

    // denote whether players have reached the checkpoint
    public bool isReached()
    {
        return first_reached;
    }
}
