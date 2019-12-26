using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedTest : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(AutoHurt());
    }

    void Update()
    {
        
    }
    IEnumerator AutoHurt(){
        while(GetComponent<Health>().health>0){
            GetComponent<Health>().ChangeHealthByAmount(-1);
            yield return new WaitForSeconds(0.5f);
        }
    }
    void OnEnable(){

    }
}
