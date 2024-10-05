using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
	public GameObject player;
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (this.GetComponent<Stats>().health <= 0)
		{
			Destroy(this.gameObject);
			
		}
	}
}
