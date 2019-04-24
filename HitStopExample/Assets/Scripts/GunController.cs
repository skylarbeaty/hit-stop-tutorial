using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	public Transform player, holder, muzzle;
	Vector3 offset, mouseVector; 
	float shotNext = 0.0f, shotTime = 0.15f;
	Animator anim;
	public GameObject bulletPrefab;
	void Start()
	{
		holder = transform.parent;
		offset = holder.position - player.position;
		anim = GetComponent<Animator>();
	}
	void Update () {
		Aim();
		Shoot();
	}
	void LateUpdate(){
		holder.position = player.position + offset;
	}
	void Aim(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
		mousePos.z = transform.position.z;
		mouseVector = (mousePos - transform.position).normalized; 
		float gunAngle = -1 * Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg; 
		holder.rotation = Quaternion.AngleAxis(gunAngle, Vector3.back); 
		if (mouseVector.x > 0)
			holder.localScale = Vector3.one;
		else
			holder.localScale = new Vector3(1.0f,-1.0f,1.0f);
		
	}
	void Shoot(){
		if (Time.time < shotNext)
			return;
		if (!Input.GetMouseButton(0))
			return;
		shotNext = Time.time + shotTime;

		anim.SetTrigger("Shoot");

		Bullet bulletObj = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity).GetComponent<Bullet>();
		bulletObj.Setup(mouseVector);
	}
}
