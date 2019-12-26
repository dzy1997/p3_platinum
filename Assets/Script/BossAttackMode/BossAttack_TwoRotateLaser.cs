using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack_TwoRotateLaser : MonoBehaviour
{
	public float holdTime = 1f;
	public float rotateSpeed = 1f;
	IEnumerator HoldAndRotateCoroutine = null;
    // Start is called before the first frame update
	void Awake()
    {
        Debug.Log(gameObject + " Awake()");
		// HoldAndRotateCoroutine = HoldAndRotate();
    }
    void Start()
    {
        Debug.Log(gameObject + " Start()");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnEnable() {
		Debug.Log(gameObject + " OnEnable()");
		// StartCoroutine(HoldAndRotateCoroutine);
	}
	private void OnDisable() {
		Debug.Log(gameObject + " OnDisable()");
		// StopCoroutine(HoldAndRotateCoroutine);
	}
	IEnumerator HoldAndRotate() {
		yield return new WaitForSeconds(holdTime);
		while(true){
			transform.Rotate(new Vector3(0f, 0f, rotateSpeed) );
			yield return null;
		}
	}
}
