using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
	
	public Vector3 AimingDiretion
	{
		set{
			_aimingDirection = value.normalized;
			//Debug.Log("Aiming at:"+ _aimingDirection);
		}
		get{
			return _aimingDirection;
		}
	}
	Vector3 _aimingDirection;

}
