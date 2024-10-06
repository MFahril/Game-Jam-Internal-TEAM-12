using System.Collections;
using System.Collections.Generic;
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
	public float recoilStrength = 5f;
	private PlayerMovement playerMovement;

	private Rigidbody2D playerRb; // Player's Rigidbody2D

	void Start()
	{
		// Get the player's Rigidbody2D component
		playerRb = GetComponent<Rigidbody2D>();
		playerMovement = GetComponent<PlayerMovement>();
	}

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
		// Instantiate the bullet at the firePoint's position and rotation
		GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
		Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
		
		// Add force to the bullet to shoot it forward
		bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

		// Set bullet damage based on player stats
		bulletPrefabs.GetComponent<Stats>().damage = this.GetComponent<Stats>().damage;
		
		ApplyRecoilKnockback();
	}

	public void ThrowGrenade()
	{
		GameObject grenade = Instantiate(grenadePrefabs, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * grenadeForce, ForceMode2D.Impulse);
	}
	
	private void ApplyRecoilKnockback()
	{
		// Calculate the recoil direction (opposite to the firePoint's direction)
		Vector2 recoilDirection = -firePoint.up;

		// Apply recoil to the player through PlayerMovement script
		playerMovement.ApplyRecoil(recoilDirection * recoilStrength);
	}

}
