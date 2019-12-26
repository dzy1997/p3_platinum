﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SmashFront : Ability
{
	public GameObject smashwavePrefab;
	public GameObject Player = null;
	Aiming aiming;
	bool isCooledDown = false;
	private void Start() {
		if(Player == null){
			Debug.LogWarning(gameObject + "'s Ability does not specify Player");
		}
		aiming = Player.GetComponent<Aiming>();
	}
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
		GameObject smashwave = Instantiate(smashwavePrefab, transform.position + aiming.AimingDiretion*3, Quaternion.identity);
		smashwave.GetComponent<SmashWave>().SetActiveTime(activeTime);
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
