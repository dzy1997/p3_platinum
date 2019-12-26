using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CreateStunWave : Ability
{
	public GameObject stunwavePrefab;
	bool isCooledDown = false;
	override public void Launch()
	{
		if(!isCooledDown){
			StartCoroutine(Launch_R());
			StartCoroutine(CountCooldown());
			StartSideEffect();
		}
	}
	override public void StartSideEffect()
	{
		
	}
	IEnumerator Launch_R(){
		isUsing = true;
		OnLaunch.Invoke();
		yield return new WaitForSeconds(startUpTime);
		GameObject stunwave = Instantiate(stunwavePrefab, transform.position, Quaternion.identity);
		stunwave.GetComponent<StunWave>().SetActiveTime(activeTime);
		yield return new WaitForSeconds(activeTime);
		yield return new WaitForSeconds(recoveryTime);
		OnEnd.Invoke();
		isUsing = false;
	}

	IEnumerator CountCooldown(){
		isCooledDown = true;
		cooldownCounter = 0f;
		while(cooldownCounter < cooldown){
			cooldownCounter += Time.deltaTime;
			yield return null;
		}
		isCooledDown = false;
	}
	private void OnDisable() {
		isCooledDown = false;
		cooldownCounter = cooldown;
		isUsing = false;
	}
}
