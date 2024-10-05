using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float lifeTime = 3;
	private Rigidbody2D rb;
	public GameObject enemy;
	
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		Destroy(gameObject, lifeTime);
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<Stats>().health -= this.GetComponent<Stats>().damage;
			
			Destroy(this.gameObject);
		}
	}
}
