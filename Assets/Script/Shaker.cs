using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Shaker : MonoBehaviour
{
 
    public float k = 0.2f;
    public float dampening_factor = 0.85f;
    public float debug_displacement = 1.0f;
	private Vector3 startingLocalPosition;
 
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
		startingLocalPosition = transform.localPosition;
    }
 
    Vector3 velocity = Vector3.zero;
 
    public void Bump(Vector3 force)
    {
        velocity += new Vector3(force.x, force.y, 0) * 10f;
        // velocity += UnityEngine.Random.onUnitSphere * 0.05f;
		Debug.Log("bump!");
		Debug.Log(velocity);
    }
 
    // Update is called once per frame
    void Update()
    {
        // f = kd
        // f = ma
        // a = kd
 
        Vector3 d = -(transform.localPosition - startingLocalPosition);
        Vector3 acceleration = k * d;
 
        Vector3 vel_delta = acceleration - velocity * (1.0f - dampening_factor);
        velocity += vel_delta * Time.deltaTime * Application.targetFrameRate;
        transform.localPosition += velocity;
    }
}