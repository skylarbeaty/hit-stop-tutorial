using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	float speed = 5;
	Animator anim;
	SpriteRenderer rend;
	int layerOrderNorm = 90, layerOrderBack = 110;
	void Start(){
		anim = GetComponent<Animator>();
		rend = GetComponent<SpriteRenderer>();
	}
	void Update () {
		Move();
	}
	void Move(){
		//capture inpupt
		Vector2 moveVect = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (moveVect.magnitude > 1)
			moveVect = moveVect.normalized;
		//move player
		transform.position = transform.position + (Vector3)(moveVect * speed * Time.deltaTime);
		//animations
		bool running = ((Mathf.Abs(moveVect.x) > 0.0f) || (Mathf.Abs(moveVect.y) > 0.0f));
		bool forward = (moveVect.y <= 0.0f);
		anim.SetBool("Forward", forward);
		anim.SetBool("Running", running);

		if (moveVect.x > 0.0f)
			transform.localScale = Vector3.one;
		else if (moveVect.x < 0.0f) //dont flip on x == 0
			transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
		
		if (forward)
			rend.sortingOrder = layerOrderNorm;
		else 
			rend.sortingOrder = layerOrderBack;
	}	
}
