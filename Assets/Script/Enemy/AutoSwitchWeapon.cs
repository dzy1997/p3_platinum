using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSwitchWeapon : MonoBehaviour
{
    // Put weapons in children
    // Start is called before the first frame update
    public GameObject[] weaponGroups;
    public float[] times;
    public float waitTime = 1f;
    void Start()
    {
        foreach (GameObject group in weaponGroups){
            group.SetActive(false);
        }
        StartCoroutine(AttackSchedule());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ActivateGroup(GameObject group){
        group.SetActive(true);
        for (int i = 0; i<group.transform.childCount; i++){
            Reset_state rs = group.transform.GetChild(i).GetComponent<Reset_state>();
            if (rs) rs.reset_state();
        }
    }

    void DeactivateGroup(GameObject group){
        group.SetActive(false);
    }

    IEnumerator AttackSchedule(){
        int i = 0;
        while (true){
            ActivateGroup(weaponGroups[i]);
            yield return new WaitForSeconds(times[i]);
            DeactivateGroup(weaponGroups[i]);
            yield return new WaitForSeconds(waitTime);
            i = (i+1) % weaponGroups.Length;
        }
    }
}
