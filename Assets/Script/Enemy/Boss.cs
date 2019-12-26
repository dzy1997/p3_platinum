using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Text bossHealthText;
    public BossCheckpoint prev_ckpt, next_ckpt;
    public bool following = true; // whether Boss is following players
    float targetHealth;
    // Start is called before the first frame update
    private Vector3 prev_pos, next_pos, curr_pos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bossHealthText.text = "Boss health: "+GetComponent<Health>().health.ToString();
        if (!following && GetComponent<Health>().health<targetHealth){
            ReachCheckpoint(next_ckpt);
            following = true;
        } 
        if (following) followPlayers();
        prev_pos = prev_ckpt.transform.position;
        next_pos = next_ckpt.transform.position;
        curr_pos = transform.position;
        if ((next_pos-curr_pos).magnitude<0.1f){
            ReachCheckpoint(next_ckpt);
        }
    }

    void followPlayers(){
        prev_pos = prev_ckpt.transform.position;
        next_pos = next_ckpt.transform.position;
        curr_pos = transform.position;
        Vector3 avg = GetAvgPos();
        Vector3 projection = Vector3.Project(avg-prev_pos,next_pos-prev_pos);
        if (projection.magnitude>(curr_pos-prev_pos).magnitude){
            transform.position = prev_pos + projection;
        }else{
            Debug.Log("not going back");
        }
    }

    void ReachCheckpoint(BossCheckpoint ckpt){
        if (ckpt.reached) return;
        ckpt.reached = true;
        Debug.Log(ckpt.gameObject.name+" reached");
        transform.position = ckpt.transform.position;
        foreach (GameObject obj in ckpt.spawnedObjects){
            for (int i=0; i<obj.transform.childCount; i++){
                Transform tr = obj.transform.GetChild(i);
                GetComponent<ExplosionParticleGenerator>().Generate_givenposition(tr.position);
            }
            obj.SetActive(true);
        }
        prev_ckpt = ckpt;
        next_ckpt = ckpt.nextckpt;
        if (ckpt.targetHealth != 0){
            following = false;
            targetHealth = ckpt.targetHealth;
        }
    }

    Vector3 GetAvgPos(){
        GameObject[] players = GameController.GetInstance().players;
        Vector3 avg = Vector3.zero;
        int n = 0;
        for (int i=0; i<players.Length; i++){
            if (!players[i].GetComponent<Health>().isDead){
                avg += players[i].transform.position;
                n++;
            }
        }
        if (n==0) return avg;
        avg /= n;
        return avg;
    }
    
    void OnTriggerEnter2D(Collider2D col){

    }
}
