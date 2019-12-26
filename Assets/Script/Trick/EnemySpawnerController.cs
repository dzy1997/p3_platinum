using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject enemy = null;
	public float spawnPeriod = 1f;
	float counter = 0f;

    // Update is called once per frame
    void Update()
    {
		if(enemy == null){
			return;
		}
        if(counter >= spawnPeriod){
			Instantiate(enemy, transform.position, Quaternion.identity);
			counter = 0f;
		}
		counter += Time.deltaTime;
    }
}
