using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnergyRegenerator : MonoBehaviour
{
	public int shieldHealthRecoverySpeed = 1;
	public float shieldHelathRecoveryDelay = 1f;
	Health shieldHealth;
	EquipmentOpenClose openclose;
	IEnumerator ShieldRecoverRoutine;
    // Start is called before the first frame update
    void Awake()
    {
        shieldHealth = GetComponent<Health>();
		openclose = GetComponent<ShieldOpenClose>();
    }

    // Update is called once per frame
    void Update()
    {
		if(shieldHealth.health <= 0){
			openclose.Close();
		}
    }
	public void StartRecoverEnergy(){
		if(ShieldRecoverRoutine == null){
			ShieldRecoverRoutine = ShieldRecover();
			StartCoroutine(ShieldRecoverRoutine);
		}
	}
	public void StopRecoverEnergy(){
		if(ShieldRecoverRoutine != null){
			StopCoroutine(ShieldRecoverRoutine);
			ShieldRecoverRoutine = null;
		}
	}
	IEnumerator ShieldRecover(){
		yield return new WaitForSeconds(shieldHelathRecoveryDelay);
		while(true){
			shieldHealth.ChangeHealthByAmount(shieldHealthRecoverySpeed);
			yield return new WaitForSeconds(0.1f);
		}
	}

	private void OnDisable() {
		shieldHealth.ChangeHealthByAmount(shieldHealth.maxHealth);
	}
}
