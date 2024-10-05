using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public GameObject bulletPrefabs;
	public GameObject grenadePrefabs;
	public Transform firePoint;
	public float bulletForce = 20f;
	public float grenadeForce = 10f;
	public float fireRate = 0.3f;
	private float fireTimeer;
	
	void Update()
	{
		// Bullet shoot
		if (Input.GetButton("Fire1") && fireTimeer <= 0f)
		{
			Shooting();
			fireTimeer = fireRate;
		}
		else
		{
			fireTimeer -= Time.deltaTime;
		}
		
		// Grenade throw
		if (Input.GetButtonDown("Fire2"))
		{
			ThrowGrenade();
		}
	}
	private void Shooting()
	{
		GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
		
		bulletPrefabs.GetComponent<Stats>().damage = this.GetComponent<Stats>().damage;
	}
	
	public void ThrowGrenade()
	{
		GameObject grenade = Instantiate(grenadePrefabs, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
	}
	
}
