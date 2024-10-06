using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float dashSpeed = 20f;      
	public float dashDuration = 0.2f;  
	public float dashCooldown = 1f;    
	public float recoilForceDecayRate = 5f; // How quickly the recoil force decays
	private bool isDashing = false;    
	private float dashTimeLeft;        
	private float dashCooldownTime;    
	private Vector2 recoilForce = Vector2.zero; // Stores the recoil force applied to the player

	public Rigidbody2D rb;
	public Camera cam;
	Vector2 movement;
	Vector2 mousePos;

	void Update()
	{
		// Capture movement input
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		// Normalize the movement vector to ensure consistent speed in all directions
		if (movement.magnitude > 1)
		{
			movement.Normalize();
		}

		// Capture mouse position
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

		// Handle dash input
		if (Input.GetKeyDown(KeyCode.Space) && dashCooldownTime <= 0 && !isDashing)
		{
			StartDash();
		}

		// Update dash timers
		if (isDashing)
		{
			dashTimeLeft -= Time.deltaTime;
			if (dashTimeLeft <= 0)
			{
				EndDash();
			}
		}
		else
		{
			dashCooldownTime -= Time.deltaTime;
		}

		// Decay recoil force over time
		recoilForce = Vector2.Lerp(recoilForce, Vector2.zero, recoilForceDecayRate * Time.deltaTime);
		
		if (this.GetComponent<Stats>().health <= 0)
		{
			Destroy(this.gameObject);
		}
	}

	private void FixedUpdate()
	{
		Vector2 finalMovement = movement * moveSpeed;

		// Add the recoil force to the final movement
		if (isDashing)
		{
			// Dash movement (fast movement)
			rb.MovePosition(rb.position + finalMovement * dashSpeed * Time.fixedDeltaTime);
		}
		else
		{
			// Regular movement with recoil
			rb.MovePosition(rb.position + (finalMovement + recoilForce) * Time.fixedDeltaTime);
		}

		// Rotate player to face mouse pointer
		Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;
	}

	private void StartDash()
	{
		isDashing = true;
		dashTimeLeft = dashDuration;
		dashCooldownTime = dashCooldown;
	}

	private void EndDash()
	{
		isDashing = false;
	}

	// This method allows the shooting script to apply recoil to the player
	public void ApplyRecoil(Vector2 recoil)
	{
		recoilForce += recoil;
	}
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			this.GetComponent<Stats>().health  -= other.GetComponent<Stats>().damage;
		}
	}
}
