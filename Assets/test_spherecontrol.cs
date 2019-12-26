using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class test_spherecontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Gamepad.current == null)
			return;

		transform.position = Gamepad.current.rightStick.ReadValue()*3;
    }
}
