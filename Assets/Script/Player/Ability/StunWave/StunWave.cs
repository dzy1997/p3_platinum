using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunWave : MonoBehaviour
{
	public void SetActiveTime(float activeTime){
		StartCoroutine(ActiveProcess(activeTime) );
	}
    private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag != "Player"){
			Debug.Log(other + "should be stunned");
			debuff_controller dc = other.GetComponent<debuff_controller>();
			if(dc != null)
				dc.Set_stun();
		}
	}

	IEnumerator ActiveProcess(float activeTime){
		yield return new WaitForSeconds(activeTime);
		Destroy(gameObject);
	}
}
