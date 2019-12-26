using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOpenClose : EquipmentOpenClose
{
	Collider2D cd;
	GameObject owner;
	GameObject inventory;
	GameObject holdingEquipment;
	private void Awake() {
		cd = GetComponent<Collider2D>();
		owner = GetComponent<OwnerIdentifier>().owner;
		inventory = owner.transform.Find("Inventory").gameObject;
		holdingEquipment = owner.transform.Find("HoldingEquipment").gameObject;
	}
    override public void Open()
	{
		// transform.Find("View").gameObject.SetActive(true);
		cd.enabled = true;
		isOpened = true;
		OnOpen.Invoke();
	}
	override public void Close()
	{
		// transform.Find("View").gameObject.SetActive(false);
		cd.enabled = false;
		isOpened = false;
		OnClose.Invoke();
	}
	override public void TakeOut()
	{
		transform.SetParent(holdingEquipment.transform, true);
		OnTakeOut.Invoke();
		isTakenOut = true;
		Open();
	}
	override public void TakeBack()
	{
		Close();
		transform.SetParent(inventory.transform, true);
		OnTakeBack.Invoke();
		isTakenOut = false;
	}
}
