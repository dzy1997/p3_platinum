using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIShieldEnergyBar : MonoBehaviour
{
    GameObject Player = null;
	GameObject shield = null;
	Health shieldEnergy = null;
	Image barImage = null;
	public float shakeForce = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
		Player = transform.parent.GetComponent<UIPlayerStatus>().Player;
		if(Player == null){
			Debug.LogWarning(this + "'s Player is not specified!!!");
		}
		if(Player.transform.Find("Inventory").Find("shield") != null){	
			shield = Player.transform.Find("Inventory").Find("shield").gameObject;
		}
		if(shield == null){
			shield = Player.transform.Find("HoldingEquipment").Find("shield").gameObject;
		}
		if(shield == null){
			Debug.LogWarning(this + " cannot find shield on Player!!!");
		}
		shieldEnergy = shield.GetComponent<Health>();
		barImage = transform.Find("Bar").gameObject.GetComponent<Image>();

		if(GetComponent<Shaker>() != null)
			shieldEnergy.OnDamaged.AddListener(delegate{GetComponent<Shaker>().Bump(Vector3.down * shakeForce);});
    }

    // Update is called once per frame
    void Update()
    {
        barImage.fillAmount = (float)shieldEnergy.health / (float)shieldEnergy.maxHealth;
    }
}
