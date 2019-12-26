using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

abstract public class EquipmentOpenClose : MonoBehaviour
{

	public bool isOpened;
	public bool isTakenOut;
	public UnityEvent OnOpen;
	public UnityEvent OnClose;
	public UnityEvent OnTakeOut;
	public UnityEvent OnTakeBack;
    abstract public void Open();
	abstract public void Close();
	abstract public void TakeOut();
	abstract public void TakeBack();
}
