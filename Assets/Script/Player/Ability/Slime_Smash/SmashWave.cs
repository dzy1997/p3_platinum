using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashWave : MonoBehaviour
{
    public void SetActiveTime(float activeTime){
		StartCoroutine(ActiveProcess(activeTime) );
	}
    private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag != "Player"){
			Debug.Log(other + "should be smashed");
		}
	}

	IEnumerator ActiveProcess(float activeTime){
		yield return new WaitForSeconds(activeTime);
		Destroy(gameObject);
	}
}
