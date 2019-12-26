using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
abstract public class Ability : MonoBehaviour
{
	public float startUpTime = 0f;
	public float activeTime = 3f;
	public float recoveryTime = 0f;
	public float cooldown = 5f;
	public float cooldownCounter = 5f;
	public float sideEffectTime = 5f;
	public bool isUsing = false;
	public UnityEvent OnLaunch;
	public UnityEvent OnEnd;
    abstract public void Launch();
	abstract public void StartSideEffect();
}
