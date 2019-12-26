using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerStatus : MonoBehaviour
{
	public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        if(Player == null){
			Debug.LogWarning(this + "'s Player is not specified!!!");
		}
    }
}
