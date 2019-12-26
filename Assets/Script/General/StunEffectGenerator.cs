using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEffectGenerator : MonoBehaviour
{
    public GameObject stunEffect;
	debuff_controller dc;
	GameObject stunEffectObject = null;
	private void Start() {
		dc = GetComponent<debuff_controller>();
	}
	private void Update() {
		if(stunEffectObject == null && dc.IsStun){
			stunEffectObject = Instantiate(stunEffect, transform.position, Quaternion.identity, transform);
		}
		if(!dc.IsStun && stunEffectObject != null){
			Destroy(stunEffectObject);
			stunEffectObject = null;
		}
	}
}
