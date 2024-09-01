using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
   
    private Rigidbody2D m_Rigidbody2D;

    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // How much to smooth out the movement
    float horizontalMove = 0f;
    
    public Animator animator;
    public float runSpeed = 40f;
    public float fireRadius = 40;

    public Joystick joystick;
    public bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        
    }

    Vector3 targetVelocity;
    Collider2D nearestTarget;
    void FixedUpdate()
    {
        // Move our character

         targetVelocity = new Vector2(horizontalMove * Time.fixedDeltaTime * 10f, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        // If the input is moving the player right and the player is facing left...
        if (horizontalMove * Time.fixedDeltaTime > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalMove * Time.fixedDeltaTime < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        nearestTarget = FindNearestTarget();
        if (nearestTarget != null && targetVelocity.magnitude==0)
        {
            if (transform.position.x < nearest.transform.position.x && !m_FacingRight)
            {
                Flip();
            }
            else if(transform.position.x > nearest.transform.position.x && m_FacingRight)
            {
                Flip();
            }
        }
    }
    Collider2D nearest = null;

    private Collider2D FindNearestTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, fireRadius);
        
        float minDistance = float.MaxValue;
        foreach (var hit in hits)
        {
            if (hit.CompareTag("enemy")) // ignore if specific 
            {
                float distance = Vector2.Distance(transform.position, hit.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = hit;
                }
            }
        }
      
 
        return nearest;
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
