using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIAbilityCooldownBar : MonoBehaviour
{
	GameObject Player = null;
	Image barImage = null;
	Ability ability = null;
	public float shakeForce = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Player = transform.parent.GetComponent<UIPlayerStatus>().Player;
		if(Player == null){
			Debug.LogWarning(this + "'s Player is not specified!!!");
		}
		ability = Player.transform.Find("Ability").gameObject.GetComponent<Ability>();
		if(ability == null){
			Debug.LogWarning(this + "'s Player does not have Ability!!!");
		}
		
		barImage = transform.Find("Bar").gameObject.GetComponent<Image>();

		if(GetComponent<Shaker>() != null)
			ability.OnLaunch.AddListener(delegate{GetComponent<Shaker>().Bump(Vector3.down * shakeForce);});
    }

    // Update is called once per frame
    void Update()
    {
        barImage.fillAmount = (float)ability.cooldownCounter / (float)ability.cooldown;
    }
}
