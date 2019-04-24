using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFade : MonoBehaviour {
	public Vector3 moveDir;
	float speed = 0.2f, fadeSpeed = 2.0f;
	SpriteRenderer rend;
	void Start(){
		rend = GetComponent<SpriteRenderer>();
		moveDir = moveDir.normalized;
		Destroy(transform.parent.gameObject, 2.0f);
	}
	void Update () {
		transform.position = transform.position + moveDir * speed * Time.deltaTime;
		Color color = rend.color;
		color.a -= fadeSpeed * Time.deltaTime;
		if (color.a < 0.0f)
			Destroy(gameObject);
		rend.color = color;
	}
}
