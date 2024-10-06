using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
	public GameObject player;
	public void Update()
	{
		if (this.GetComponent<Stats>().health <= 0)
		{
			Destroy(this.gameObject);
			GameManager.Instance.killCounter++;
			Debug.Log(GameManager.Instance.killCounter);
		}
	}
}
