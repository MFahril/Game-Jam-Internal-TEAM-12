using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public GameObject bulletPrefabs;
	public Transform firePoint;
	public float bulletForce = 20f;
	public float fireRate = 0.3f;
	private float fireTimeer;
	
	void Update()
	{
		if (Input.GetButton("Fire1") && fireTimeer <= 0f)
		{
			Shooting();
			fireTimeer = fireRate;
		}
		else
		{
			fireTimeer -= Time.deltaTime;
		}
	}
	private void Shooting()
	{
		GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
		
		bulletPrefabs.GetComponent<Stats>().damage = this.GetComponent<Stats>().damage;
	}
	
	
}
