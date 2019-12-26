using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldViewController : MonoBehaviour
{
	GameObject owner;
	SpriteRenderer spriteRenderer;
	Health shieldHealth;
	Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
		animator = GetComponent<Animator>();
		owner = transform.parent.gameObject.GetComponent<OwnerIdentifier>().owner;
		spriteRenderer = GetComponent<SpriteRenderer>();
		shieldHealth = transform.parent.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
		spriteRenderer.color = new Color(1f, 1f, 1f, (float)(shieldHealth.health)/shieldHealth.maxHealth);
    }
	
	public void Open()
	{
		animator.SetBool("isOpened", true);
		animator.SetFloat("OpenSpeed", 1f);
	}
	public void Close()
	{
		animator.SetBool("isOpened", false);
		animator.SetFloat("OpenSpeed", -1f);
	}
}
