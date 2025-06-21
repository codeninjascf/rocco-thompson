using UnityEngine;

public class EnemyPatrollers : MonoBehaviour
{
    public Transform[] patrolPoints; // Array of points for the enemy to patrol between
    private int currentPoint; // Index of the current patrol point
    public float moveSpeed, waitAtPoints, jumpForce; // Movement speed, wait time at points, and jump force
    private float waitCounter; // Counter for waiting at patrol points
    public Rigidbody2D theRB; // Rigidbody component for physics
    public Animator anim; // Animator component for animations

    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitAtPoints; // Initialize wait counter with the wait time

        // Detach patrol points from their parent to avoid moving them with the enemy
        foreach (Transform pPoint in patrolPoints)
        {
            pPoint.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the enemy is close enough to the current patrol point
        if (Mathf.Abs(transform.position.x - patrolPoints[currentPoint].position.x) > .2f)
        {
            // Check if the enemy needs to jump to reach the patrol point
            if (transform.position.y < patrolPoints[currentPoint].position.y - .5f && theRB.velocity.y < .1f)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce); // Apply jump force
                transform.localScale = new Vector3(-1f, 1f, 1f); // Flip the enemy's sprite
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y); // Move the enemy towards the patrol point
                waitCounter -= Time.deltaTime; // Decrease wait counter
                if (waitCounter <= 0)
                {
                    waitCounter = waitAtPoints; // Reset wait counter

                    currentPoint++; // Move to the next patrol point

                    // Loop back to the first patrol point if at the end of the array
                    if (currentPoint >= patrolPoints.Length)
                    {
                        currentPoint = 0;
                    }
                }
            }
        }
        else if (transform.position.x < patrolPoints[currentPoint].position.x)
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y); // Move the enemy towards the patrol point
            transform.localScale = Vector3.one; // Reset the enemy's sprite scale
            waitCounter -= Time.deltaTime; // Decrease wait counter

            if (waitCounter <= 0)
            {
                waitCounter = waitAtPoints; // Reset wait counter

                currentPoint++; // Move to the next patrol point

                // Loop back to the first patrol point if at the end of the array
                if (currentPoint >= patrolPoints.Length)
                {
                    currentPoint = 0;
                }
            }
        }

        // Update the animator with the enemy's speed
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
    }
}
