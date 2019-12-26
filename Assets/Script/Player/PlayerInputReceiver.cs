using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInputReceiver : MonoBehaviour
{
	Movement movement;
	Aiming aiming;
	Vector2 movementInput;
	Vector2 aimingInput;

    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<Movement>();
		aiming = GetComponent<Aiming>();
    }

    // Update is called once per frame
    void Update()
    {

		// if(Gamepad.current != null)
		// 	aimingInput = Gamepad.current.rightStick.ReadValue();

		//Debug.Log("movementInput" + movementInput);
		// Move control
		Vector3 moveDirection = new Vector3(movementInput.x, movementInput.y, 0f).normalized;
		// Debug.Log(moveDirection);
		if(moveDirection.magnitude != 0f){
			movement.MoveAlongDirection(moveDirection);
		}
		else{
			movement.StopMoving();
		}
		
		// Aim control
		if(aimingInput.magnitude != 0f){
			aiming.AimingDiretion = new Vector3(aimingInput.x, aimingInput.y, 0f).normalized;
			// Debug.Log(aiming.AimingDiretion);
		}
    }
	// Below is for Unity's input system
	void OnMovement(InputValue value){
		movementInput = value.Get<Vector2>();
		if(movementInput.magnitude <= 0.2f)
			movementInput = Vector3.zero;
		// Debug.Log(movementInput);
	}
	void OnAiming(InputValue value){
		aimingInput = value.Get<Vector2>();
		// Debug.Log(aimingInput);
		if(GetComponent<PlayerInput>().currentControlScheme=="Keyboard&Mouse"){
			aimingInput = new Vector2((Camera.main.ScreenToWorldPoint(aimingInput) - transform.position ).x, (Camera.main.ScreenToWorldPoint(aimingInput) - transform.position ).y);
			aimingInput = aimingInput.normalized;
			// Debug.Log(aimingInput);
		}
	}
	void OnUseAbility(){
		Debug.Log("use ability");
		Ability ability = transform.Find("Ability").GetComponent<Ability>();
		ability.Launch();
	}
}
