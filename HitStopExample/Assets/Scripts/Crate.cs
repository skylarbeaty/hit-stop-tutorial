using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {
	SpriteRenderer rend;
	Shader hitShader;
	public GameObject breakPrefab;
	void Start(){
		rend = GetComponent<SpriteRenderer>();
		hitShader = Shader.Find("GUI/Text Shader");//too allow all white sprite
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Bullet")){
			//change to white
			rend.material.shader = hitShader;
			rend.material.color = Color.white;

			//trigger hit stop
			FindObjectOfType<HitStop>().Stop(0.1f);

			//call cooroutine to wait one frame, then destroy
			StartCoroutine(WaitForSpawn());
		}
	}
	IEnumerator WaitForSpawn(){
		while(Time.timeScale != 1.0f)
			yield return null;//wait for hit stop to end
		Instantiate(breakPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
