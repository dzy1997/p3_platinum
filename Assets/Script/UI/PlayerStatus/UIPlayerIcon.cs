using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPlayerIcon : MonoBehaviour
{
	GameObject Player;
	Animator animator;
	Health playerHealth;
	InvincibleTimer playerInvincibleTimer;
	public float shakeForce = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
		animator = GetComponent<Animator>();
        Player = transform.parent.GetComponent<UIPlayerStatus>().Player;
		if(Player == null){
			Debug.LogWarning(this + "'s Player is not specified!!!");
		}
		playerHealth = Player.GetComponent<Health>();
		playerInvincibleTimer = Player.GetComponent<InvincibleTimer>();
		if(GetComponent<Shaker>() != null)
			playerHealth.OnDamaged.AddListener(delegate{GetComponent<Shaker>().Bump(Vector3.down * shakeForce);});
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.isDead){
			animator.SetBool("isDead", true);
		}
		else{
			animator.SetBool("isDead", false);
		}

		if(playerInvincibleTimer.isInvincible && !playerHealth.isDead ){
			animator.SetBool("isDamaged", true);
		}
		else{
			animator.SetBool("isDamaged", false);
		}
    }
}
