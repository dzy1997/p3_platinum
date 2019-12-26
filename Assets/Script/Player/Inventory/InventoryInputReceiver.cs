using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InventoryInputReceiver : MonoBehaviour
{
    public GameObject Player;
	public List<string> EquipmentSlot;//TODO: dirty, need to move to a new component
	GameObject inventory;
	GameObject holdingEquipment;
	GameObject currentHoldingEquipment = null;
	EquipmentOpenClose openclose;
	Health equipmentHealth;
	int currentEquipmentIdx = 0;//TODO: dirty, need to move to a new component
	void Start() {
		if(Player == null){
			Debug.LogWarning(gameObject + "'s InventoryInput does not specify Player");
		}
		inventory = Player.transform.Find("Inventory").gameObject;
		holdingEquipment = Player.transform.Find("HoldingEquipment").gameObject;

		// Close everything that should be in Inventory
		for(int i=0; i<inventory.transform.childCount; i++ ){//TODO: dirty, need to move to a new component
			GameObject equipment = inventory.transform.GetChild(i).gameObject;
			equipment.GetComponent<EquipmentOpenClose>().TakeBack();
		}
		// Open that one thing that should be in HoldingEquipment
		for(int i=0; i<holdingEquipment.transform.childCount; i++ ){ //TODO: dirty, need to move to a new component
			GameObject equipment = holdingEquipment.transform.GetChild(i).gameObject;
			equipment.GetComponent<EquipmentOpenClose>().TakeOut();
			equipment.GetComponent<EquipmentOpenClose>().Close();
		}

		// Fetch information of current holding equipment
		if(holdingEquipment.transform.childCount > 0){
			currentHoldingEquipment = holdingEquipment.transform.GetChild(0).gameObject;
		}
		openclose = currentHoldingEquipment.GetComponent<EquipmentOpenClose>();
		equipmentHealth = currentHoldingEquipment.GetComponent<Health>();
	}
	// void SwapEquipment(){
	// 	//TODO: dirty, need to move to a new component
	// 	// Equipment roller swaper
	// 	int newEquipmentIdx = currentEquipmentIdx + 1;
	// 	newEquipmentIdx %= EquipmentSlot.Count;
	// 	Debug.Log(newEquipmentIdx);
	// 	// Close current holding equipment
	// 	if(holdingEquipment.transform.childCount > 0){
	// 		GameObject currentHoldingEquipment = holdingEquipment.transform.GetChild(0).gameObject;
	// 		currentHoldingEquipment.GetComponent<EquipmentOpenClose>().TakeBack();
	// 	}
	// 	// Open new holding equipment
	// 	if(inventory.transform.Find(EquipmentSlot[newEquipmentIdx] ) == null){
	// 		Debug.LogWarning("EquipmentSlot " + newEquipmentIdx + " is empty or cannot be found under gameObject Inventory.");
	// 	}
	// 	else{
	// 		GameObject newHoldingEquipment = inventory.transform.Find(EquipmentSlot[newEquipmentIdx] ).gameObject;
	// 		newHoldingEquipment.GetComponent<EquipmentOpenClose>().TakeOut();
	// 	}
	// 	currentEquipmentIdx = newEquipmentIdx;
	// }
	void OpenCloseEquipment(bool toOpen){
		//TODO: dirty, need to move to a new component
		// Open-close roller
		
		if(currentHoldingEquipment == null){
			return;
		}

		if(toOpen==false && openclose.isOpened){
			openclose.Close();
		}
		else if(toOpen && !openclose.isOpened && equipmentHealth != null && !equipmentHealth.isDead){
			openclose.Open();
		}
	}

	// Below is for Unity's input system

	// void OnSwapEquipment(){
	// 	SwapEquipment();
	// }
	void OnOpenCloseEquipment(InputValue value){
		Vector2 input = value.Get<Vector2>();
		// Debug.Log(input);
		// Debug.Log(input.magnitude > 0.5f);
		if(input.magnitude > 0.5f){
			OpenCloseEquipment(true);
		}
		else{
			OpenCloseEquipment(false);
		}
	}
}
