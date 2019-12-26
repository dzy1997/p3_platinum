using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Movement : MonoBehaviour
{
	public float speed = 10f;
	public bool isMoving
	{
		get{
			return _isMoving;
		}
	}
	public Vector3 direction
	{
		get{
			return _direction;
		}
	}
	public UnityEvent OnStartMoving;
	public UnityEvent OnStopMoving;
	bool _isMoving = false;
	Vector3 _direction;
	Rigidbody2D rb;
	
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	public void MoveAlongDirection(Vector3 direction)
	{
		
		_direction = direction.normalized;
		rb.velocity = _direction * speed;
		//Debug.Log("Moving in:" + rigidbody.velocity);
		if(!_isMoving ){
			OnStartMoving.Invoke();
		}
		_isMoving = true;
	}
	public void StopMoving()
	{
		if(_isMoving ){
			OnStopMoving.Invoke();
			_isMoving = false;
			rb.velocity = Vector3.zero;
			//Debug.Log("Stop Moving");
		}
	}
}
