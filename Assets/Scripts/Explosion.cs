using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public float lifeTime = 0.1f;
	
	public void Update()
	{
		Destroy(this.gameObject, lifeTime);
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Enemy"))
		{
			other.GetComponent<Stats>().health -= this.GetComponent<Stats>().damage;
			
			Destroy(this.gameObject, lifeTime);
		}
	}
}
