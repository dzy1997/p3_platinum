using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerIdentifier : MonoBehaviour
{
	[SerializeField]private GameObject _owner;
    public GameObject owner{
		get{
			return _owner;
		}
	}
	void Start() {
		if(owner == null){
			Debug.LogWarning(gameObject + "'s OwnerIdentifier does not specify owner");
		}
	}
}
