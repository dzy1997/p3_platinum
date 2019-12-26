using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticleGenerator : MonoBehaviour
{
    // denote the offset position from the original object
    public Vector3 offset;
    // denote the lasting time of particle system
    public float lasting_time = 1f;

    public GameObject particleObjectPrefab;
	public void Launch(){
		GameObject particleObject = Instantiate(particleObjectPrefab, transform.position + offset, Quaternion.identity);
        particleObject.GetComponent<ParticleController>().lastingTime = lasting_time;
		particleObject.GetComponent<ParticleController>().Launch();
	}

    public void Generate_givenposition(Vector3 pos){
		GameObject particleObject = Instantiate(particleObjectPrefab, pos, Quaternion.identity);
        particleObject.GetComponent<ParticleController>().lastingTime = lasting_time;
		particleObject.GetComponent<ParticleController>().Launch();
	}


	
}
