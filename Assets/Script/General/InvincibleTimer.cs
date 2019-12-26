using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleTimer : MonoBehaviour
{
	public float invincibleLength = 2f;
	
	public bool isInvincible{
		get{
			return _isInvincible;
		}
	}
	bool _isInvincible = false;

	public void GoInvincible(){
		StartCoroutine(InvincibleProcess() );
	}
	IEnumerator InvincibleProcess(){
		_isInvincible = true;
		yield return new WaitForSeconds(invincibleLength);
		_isInvincible = false;
	}
	private void OnDisable() {
		_isInvincible = false;
	}

	public void SetInvicible(bool inv){
		_isInvincible = inv;
	}
}
