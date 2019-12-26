using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
	public float lastingTime = 1f;
	ParticleSystem particleSystem;
	void Awake(){
		particleSystem = GetComponent<ParticleSystem>();
	}
	public void Launch(){
		StartCoroutine(ParticleLaunch() );
	}
    IEnumerator ParticleLaunch(){
		if(particleSystem != null ){
			particleSystem.Play();
			yield return new WaitForSeconds(lastingTime );
		}
		Destroy(gameObject);
	}
}
