using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float lifeTime = 3;
	private Rigidbody2D rb;
	
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		Destroy(gameObject, lifeTime);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
