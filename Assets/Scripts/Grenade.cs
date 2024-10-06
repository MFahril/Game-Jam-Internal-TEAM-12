using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
	public GameObject explosionPrefabs;
	public float lifeTime = 1f;
	public void Update()
	{
		Invoke("Explosion", lifeTime);
		Debug.Log("WEEEEEEE");
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Enemy"))
		{
			GameObject explode = Instantiate(explosionPrefabs, this.transform.position, Quaternion.identity);
				
			Destroy(this.gameObject);
		}
	}
	
	public void Explosion()
	{
		// lifeTime -= Time.deltaTime;
		
		// if (lifeTime <= 0)
		// {
			GameObject explode = Instantiate(explosionPrefabs, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		// }
	}
	
}
