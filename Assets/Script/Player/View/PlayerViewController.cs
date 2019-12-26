using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerViewController : MonoBehaviour
{
	public GameObject Player;
    Aiming aiming;
	Animator animator;
	Ability ability;
    // Start is called before the first frame update
    void Start()
    {
		if(Player == null){
			Debug.LogWarning(gameObject + "'s View's PlayerViewController does not specify Player");
		}
        aiming = Player.GetComponent<Aiming>();
		animator = GetComponent<Animator>();
		ability = Player.transform.Find("Ability").GetComponent<Ability>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("LookX", aiming.AimingDiretion.x);
		animator.SetFloat("LookY", aiming.AimingDiretion.y);
		animator.SetBool("UsingAbility", ability.isUsing);
    }
}
