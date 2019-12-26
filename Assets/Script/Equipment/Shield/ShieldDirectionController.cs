using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDirectionController : MonoBehaviour
{
	Aiming aiming;
    // Start is called before the first frame update
    void Start()
    {
        aiming = GetComponent<OwnerIdentifier>().owner.GetComponent<Aiming>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = aiming.AimingDiretion;
    }
}
