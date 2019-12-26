using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // the text it will control
    public Show_text info;
    // denote the respawn offset
    public Vector3 offset;

    private bool reached;

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player" && !reached){
            reached = true;
            Health h = other.gameObject.GetComponent<Health>();
            h.ChangeHealthByAmount(h.maxHealth);
            // GetComponent<SpriteRenderer>().enabled = false;
            GameController.GetInstance().currentCheckpoint = this;
            GameController.GetInstance().respawn_offset = offset;
            GameController.GetInstance().RespawnPlayers();
            info.Display_txt("Check Point!", 2f);
        }
        // if some one is dead, respawn the player
        else if (other.gameObject.tag == "Player" && reached)
        {
            GameController.GetInstance().currentCheckpoint = this;
            GameController.GetInstance().respawn_offset = offset;
            GameController.GetInstance().RespawnPlayers();
        }
    }

}
