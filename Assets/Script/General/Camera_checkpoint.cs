using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_checkpoint : MonoBehaviour
{
    // denote the air wall it controlls
    public GameObject wall_in;
    public GameObject wall_out;

    // denote the players it watches
    public GameObject player1;
    public GameObject player2;
    private bool reached_1;
    private bool reached_2;

    // Start is called before the first frame update
    public bool reached = false;
    public bool fixX = false, fixY = false, fixZ = true;
    public float fixXval, fixYval, fixZval = -10f;
    public bool special_look;
    public Vector3 camDest = Vector3.zero;
    public Vector3 offset_cam = Vector3.zero;


    // used by outside to reset the camera checkpoint
    public void reset_state()
    {
        wall_in.GetComponent<BoxCollider2D>().enabled = true;
        if (wall_out)
            wall_out.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Update()
    {
        // only work if players are reborn
        if (reached)
        {
            set_cam();
            return;
        }
        // the first time they reach the checkpoint
        if (reached_1 && reached_2 && !reached)
        {
            set_cam();
            wall_in.GetComponent<BoxCollider2D>().enabled = false;
            if (wall_out)
                wall_out.GetComponent<BoxCollider2D>().enabled = true;
        }
        // once two players all died set the wallin on
        
        if (player1.GetComponent<Health>().isDead && player2.GetComponent<Health>().isDead)
        {
            reached_1 = false;
            reached_2 = false;
            wall_in.GetComponent<BoxCollider2D>().enabled = true;
            if (wall_out)
                wall_out.GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (reached)
            return;
        // first check the state of reached
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player1.GetComponent<Health>().isDead && !player2.GetComponent<Health>().isDead)
                reached_1 = true;
            if (player2.GetComponent<Health>().isDead && !player1.GetComponent<Health>().isDead)
                reached_2 = true;
        }

        if (collision.gameObject == player1)
            reached_1 = true;
        if (collision.gameObject == player2)
            reached_2 = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player1)
            reached_1 = false;
        if (collision.gameObject == player2)
            reached_2 = false;
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
        return reached_1 && reached_2;
    }
}
