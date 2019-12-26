using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text winText;
    public Text newGameText;
    public Checkpoint currentCheckpoint = null;
    public GameObject[] players;
    // denote the next level it goes
    public string next_level;
    // denote the fade animator
    public Animator fade_anim;

    // denote the respawn position
    public Vector3 respawn_loc;
    // denote the respawn offset
    public Vector3 respawn_offset;
    // denote the text you want to show when level is ended
    public string word_transtion;

    // denote the level end lock
    private bool inTransition;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        inTransition = false;
    }

    // Update is called once per frame
    void Update()
    {
        int num_alive = 0;
        for (int i=0; i<players.Length; i++){
            Health health = players[i].GetComponent<Health>();
            if (!health.isDead){
                num_alive += 1;
                // SceneManager.LoadScene("Level_LAB");
            }else{
                health.gameObject.SetActive(false);
                // health.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        if (num_alive == 0) { StartCoroutine(reborn_players()); }
    }

    // called when both players are dead
    IEnumerator reborn_players()
    {
        yield return new WaitForSeconds(1f);
        RespawnPlayers();
    }

    public void RespawnPlayers(){ //put back to checkpoint and set to full health
        if (currentCheckpoint){
            respawn_loc = currentCheckpoint.transform.position;
        }
        Vector3 temp_pos = Vector3.zero;
        foreach (GameObject player in players)
        {
            Health h = player.GetComponent<Health>();
            // h.ChangeHealthByAmount(h.maxHealth);
            if (!h.isDead)
            {
                temp_pos += respawn_offset;
                continue;
            }
            Shine_on_hurt shine_behavior = player.GetComponent<Shine_on_hurt>();
            h.ChangeHealthByAmount(h.maxHealth);
            shine_behavior.Reset();
            player.SetActive(true);
            // player.transform.GetChild(0).gameObject.SetActive(true);
            player.transform.position = respawn_loc + temp_pos;
            temp_pos += respawn_offset;
        }
    }

    public static GameController GetInstance(){
        return GameObject.Find("EventSystem").GetComponent<GameController>();
    }

    public void EndLevel(){
        Debug.Log("player win");
        if (!inTransition)
        {
            inTransition = true;
            winText.gameObject.SetActive(true);
            newGameText.gameObject.SetActive(true);
            StartCoroutine(RestartSchedule(3));
        }
    }
    
    IEnumerator RestartSchedule(int waitSec){
        for (int i = waitSec; i>0; i--){
            newGameText.text = word_transtion + ' ' + i.ToString();
            yield return new WaitForSeconds(1f);
        }
        fade_anim.SetInteger("Fade_state", 1);
        yield return new WaitForSeconds(2.5f);
        inTransition = false;
        SceneManager.LoadScene(next_level);
    }
}
