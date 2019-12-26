using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
	GameObject Player;
	Health playerHealth;
	Image barImage;
	public float shakeForce = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
		Player = transform.parent.GetComponent<UIPlayerStatus>().Player;
		if(Player == null){
			Debug.LogWarning(this + "'s Player is not specified!!!");
		}
        playerHealth = Player.GetComponent<Health>();
		barImage = transform.Find("Bar").gameObject.GetComponent<Image>();
		if(GetComponent<Shaker>() != null)
			playerHealth.OnDamaged.AddListener(delegate{GetComponent<Shaker>().Bump(Vector3.down * shakeForce);});
    }

    // Update is called once per frame
    void Update()
    {
        barImage.fillAmount = (float)playerHealth.health / (float)playerHealth.maxHealth;
    }
}
