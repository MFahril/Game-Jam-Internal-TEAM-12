using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 20f;      // Speed during dash
    public float dashDuration = 0.2f;  // Duration of the dash
    public float dashCooldown = 0.2f;    // Cooldown time between dashes
    private bool isDashing = false;    // Is the player currently dashing?
    private float dashTimeLeft;        // Time left in the current dash
    private float dashCooldownTime;    // Time remaining for the dash cooldown

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
            dashCooldownTime -= Time.deltaTime; // Reduce the cooldown over time
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            // Dash movement (fast movement)
            rb.MovePosition(rb.position + movement * dashSpeed * Time.fixedDeltaTime);
        }
        else
        {
            // Regular movement
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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
        dashCooldownTime = dashCooldown; // Reset cooldown
    }

    private void EndDash()
    {
        isDashing = false;
    }
}
