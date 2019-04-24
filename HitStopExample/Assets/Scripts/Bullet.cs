using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	Vector3 dir;
	float speed = 10.0f, timeDestroy, lifeLength = 5.0f;
	public void Setup(Vector3 _dir){
		dir = _dir;
		timeDestroy = Time.time + lifeLength;
	}
	void Update(){
		transform.position = transform.position + dir * speed * Time.deltaTime;
		if (Time.time > timeDestroy)
			Destroy(gameObject);
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Crate")){
			Destroy(gameObject);
		}
	}
}
