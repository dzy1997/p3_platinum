using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossViewController : MonoBehaviour
{
	Animator legAnimator = null;
	Animator bodyAnimator = null;
	Animator gunAnimator = null;
	RealBoss boss = null;
    // Start is called before the first frame update
    void Awake()
    {
		boss = transform.parent.GetComponent<RealBoss>();
        legAnimator = transform.Find("leg").GetComponent<Animator>();
		bodyAnimator = transform.Find("body").GetComponent<Animator>();
		gunAnimator = transform.Find("gun").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		float movingRightOrUpSpeed = 1f;
        if(boss.velocity.x > 0){
			movingRightOrUpSpeed = 1f;
		}
		else if(boss.velocity.x < 0){
			movingRightOrUpSpeed = -1f;
		}
		else if(boss.velocity.y > 0){
			movingRightOrUpSpeed = 1f;
		}
		else if(boss.velocity.y < 0){
			movingRightOrUpSpeed = -1f;
		}
		else{
			movingRightOrUpSpeed = 0f;
		}
		legAnimator.SetFloat("movingSpeed", movingRightOrUpSpeed);
    }
}
