using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealBoss : MonoBehaviour
{
    public GameObject[] allTricks;
    public Text healthText;
    public GameObject[] bossPhases;
    public int currentPhase = 0;
    public float transitionSpeed = 5f;
    void Start(){
        ResetAllTricks();
        prev_pos = transform.position;
    }

    void ResetAllTricks(){
        foreach(GameObject trick in allTricks){
            trick.SetActive(false);
        }
    }

    private bool hold = false;
    private Vector3 prev_pos;
    void Update(){
        velocity = (transform.position-prev_pos)/Time.deltaTime;
        prev_pos = transform.position;
        float health_value = GetComponent<Health>().health;
        if (healthText) healthText.text = "Boss health:"+health_value.ToString();
        if (hold) return;
        GameObject cur_phase = bossPhases[currentPhase];
        if (health_value<=cur_phase.GetComponent<BossPhase>().targetHealth){
            if (health_value <= 0) BossDie();
            else StartCoroutine(PhaseTransition());
        }
    }
    
    public Vector3 velocity;
    public bool shooting;
    IEnumerator PhaseTransition(){
        hold = true;
        GameObject cur_phase = bossPhases[currentPhase];
        GameObject door = cur_phase.GetComponent<BossPhase>().door;
        if(door) door.SetActive(false);
        cur_phase.SetActive(false);
        Vector3 target = cur_phase.GetComponent<BossPhase>().nextpos;
        ResetAllTricks();
        GetComponent<InvincibleTimer>().SetInvicible(true);
        velocity = (target-transform.position).normalized * transitionSpeed;
        while ((target-transform.position).magnitude>transitionSpeed/30f){
            transform.position += velocity * Time.deltaTime;
            yield return 0;
        }
        currentPhase += 1;
        cur_phase = bossPhases[currentPhase];
        // cur_phase.SetActive(true);
        GetComponent<InvincibleTimer>().SetInvicible(false);
        hold = false;
    }

    public void StartPhase(){
        bossPhases[currentPhase].SetActive(true);
    }

    void BossDie(){
        Debug.Log("Boss died!");
        gameObject.SetActive(false);
    }
}
