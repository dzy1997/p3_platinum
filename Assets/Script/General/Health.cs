using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
	public int maxHealth = 10;
	public int health{
		get{
			return _health;
		}
	}
	public bool isDead{
		get{
			return _isDead;
		}
	}
	public UnityEvent OnDead;
	public UnityEvent OnHealed;
	public UnityEvent OnDamaged;
	int _health;
	bool _isDead;
	InvincibleTimer invincibleTimer = null;
	private void Awake() {
		_health = maxHealth;
		_isDead = false;
		invincibleTimer = GetComponent<InvincibleTimer>();
	}
    public void ChangeHealthByAmount(int amount){
		// Change health
		if(amount > 0){
			_health += amount;
			OnHealed.Invoke();
		}
		else if(amount < 0 ){
			if(invincibleTimer == null){
				_health += amount;
				OnDamaged.Invoke();
			}
			else if(!invincibleTimer.isInvincible){
				_health += amount;
				invincibleTimer.GoInvincible();
				OnDamaged.Invoke();
			}
		}
		// Debug.Log(gameObject.tag + _health.ToString());

		// Make sure health does not go out bound
		if(_health > maxHealth){
			_health = maxHealth;
		}
		else if(_health < 0){
			 _health = 0;
		}

		// Check death
		if(_health > 0){
			_isDead = false;
		}
		else if(_health <= 0){
			if(!_isDead){
				OnDead.Invoke();
			}
			_isDead = true;
		}

		
	}
}
