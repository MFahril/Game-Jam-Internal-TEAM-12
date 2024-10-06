using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	public List<EnemyBody> enemyList;
	public int killCounter;
	public int spawnAmount;
	private void Awake() 
	{ 
		// If there is an instance, and it's not me, delete myself.
		
		if (Instance != null && Instance != this) 
		{ 
			Destroy(this); 
		} 
		else 
		{ 
			Instance = this; 
		} 
	}
	// void Update()
	// {
	// 	foreach (EnemyBody enemy in enemyList)
	// 	{
	// 		if(enemy.isDead == true)
	// 		{
	// 			enemyList.Remove(enemy);
	// 		}
			
	// 		if(enemyList.Count == 0)
	// 		{
	// 			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	// 		}
	// 	}
	// }
}
