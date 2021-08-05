using UnityEngine;
using System.Collections;

class PlayerMovement : MonoBehaviour
{
    public Animator animator; // Animator
    private Rigidbody2D rb; // Rigidbody

    [SerializeField]
    private Collider2D col; // Collider

    [SerializeField]
    private LayerMask groundLayer; // Layer

    [SerializeField]
    private float movementSpeed = 5; // Movement speed variable

    [SerializeField]
    private float jumpForce = 10; // Jump force variable

    private bool moveLeft; // Is player moving left?
    private bool dontMove; // Is player standing still?
  
    [SerializeField]
    private GameObject projectilePrefab; // Projectile prefab game object 

    [SerializeField]
    private Transform gunfire; // Gunfire transform

    [SerializeField]
    private Transform sword; // Sword transform

    [SerializeField]
    private GameObject swordPrefab; // Sword prefab game object

    // Start is called before the first frame update
    private void Start()
    {
       rb = GetComponent<Rigidbody2D>(); // Set the rigidbody
       dontMove = true; // Don't move
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandleMoving(); // Handle moving
    }

    // Function to handle moving
    void HandleMoving()
    {
        if(dontMove) // If player not moving
        {
            StopMoving(); // Stop moving
            animator.SetFloat("Speed", 0); // Animator speed variable set to 0
        }
        else // If moving
        {
            animator.SetFloat("Speed", movementSpeed); // Animator speed variable set to the movement speed variable

            if (moveLeft) // If moving left
            {
                MoveLeft(); // Move left
                transform.localScale = new Vector3(1, 1, 1); // Player face left
            }
            else if (!moveLeft) // If moving right
            {
                MoveRight(); // Move right
                transform.localScale = new Vector3(-1, 1, 1); // Player face right
            }
        }
    }   

    // Function to allow mevement
    public void AllowMovement(bool movement)
    {
        dontMove = false; // Move
        moveLeft = movement; // Is player moving left?
    }

    // Function to forbid movement
    public void DontAllowMovement()
    {
        dontMove = true; // Dont move
    }

    // Function to jump
    public void Jump()
    {
        if (IsGrounded()) // If player is on the ground
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Set rigidbody velocity
            StartCoroutine(nameof(JumpAnimation)); // Play jump animation
        }
    }

    // Function to move left
    public void MoveLeft()
    {
        rb.velocity = new Vector2(-movementSpeed, rb.velocity.y); // Set the velocity
    }

    // Function to move right
    public void MoveRight() 
    {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y); // Set the velocity 
    }

    // Function to stop moving
    public void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y); // Set the velocity to 0
    }

    // Function to check if player is on the ground
    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return hit.collider != null;
    }

    // Function to shoot
    public void Shoot()
    {
        if (GetComponent<PlayerCollision>().gun.activeSelf) // If the gun is active
        {
            animator.SetBool("Shoot", true); // Shooting animation

            GameObject go = Instantiate(projectilePrefab, gunfire.position, Quaternion.identity); // Instantiate projectiles
            FindObjectOfType<AudioManager>().Play("gun"); // Play gun sound

            Vector3 direction = new Vector3(this.gameObject.transform.localScale.x, 0); // Direction

            go.GetComponent<Projectile>().SetUp(-direction); // Set the direction
            Destroy(go, 0.4f); // Destroy projectile in 0.4 seconds
        }
        else if (GetComponent<PlayerCollision>().sword.activeSelf) // If the sword is active
        {
            animator.SetBool("Throw", true); // Throwing animation

            GameObject go = Instantiate(swordPrefab, sword.position, Quaternion.identity); // Instantiate prefab
            FindObjectOfType<AudioManager>().Play("sword"); // Play sword sound

            Vector3 direction = new Vector3(this.gameObject.transform.localScale.x, 0); // Direction

            go.GetComponent<Projectile>().SetUp(-direction); // Set up the direction
            Destroy(go, 0.9f); // Destroy the sword prefab in 0.9 seconds
        }
    }

    // Function to stop shooting animation
    public void DontShoot()
    {
        animator.SetBool("Shoot", false); // Stop shooting animation
         
        animator.SetBool("Throw", false); // Stop throwing animation
    }

    // Function to play jumping animation
    private IEnumerator JumpAnimation()
    {
        animator.SetBool("Jump", true); 

        yield return new WaitForSeconds(1.3f);

        animator.SetBool("Jump", false);

    }
}
