using UnityEngine;

public class EnemyScript : MonoBehaviour, IntColHandler
{
    [SerializeField]
    private GameObject projectilePrefab; //Projectile prefab

    [SerializeField]
    private Transform mouth; // Mouth transform

    private Transform target; // Target transform

    [SerializeField]
    private float attackCD; // Attack cooldown

    private float lastAttackTime; // Last attack
    private bool canAttack = true; // Can the enemy attack?

    [SerializeField]
    private int hp = 100; // Health

    public ObjectMovement movement; // Movement 

    // Update is called once per frame
    void Update()
    {
        TurnToTarget(); // Turn to target
        Attack(); // Attack

    }

    // Function to shoot
    public void Shoot()
    {

        GameObject go = Instantiate(projectilePrefab, mouth.position, Quaternion.identity); // Instantiate projectie

        Vector3 direction = new Vector3(transform.localScale.x, 0); // Direction

        go.GetComponent<Projectile>().SetUp(direction); // Set up direction
        Destroy(go, 2.0f); // Destroy projectile in 2 seconds
    }

    // Function to attack
    private void Attack()
    {
        if(!canAttack) // If enemy can't attack
        {
            lastAttackTime += Time.deltaTime;  // Last attack time

        }

        if(lastAttackTime >= attackCD) // If attack cooldown is over
        {
            canAttack = true; // Can attack
        }

        if (canAttack && target != null) // If enemy can attack and there is a target
        {
            canAttack = false; // Can't attack
            lastAttackTime = 0; // Last attack time

            if (mouth != null)  
            {
                Shoot(); // Shoot
            }
            
        }
    }

    // Function to turn to target
    private void TurnToTarget()
    {
        if(target != null) // If there is a target
        {
            Vector3 scale = transform.localScale; // Current scale
            scale.x = target.transform.position.x < transform.position.x ? -1 : 1; // Scale x axis is either 1 or -1

            transform.localScale = scale; // New scale
        }
    }

    // Function to take damage
    public void TakeDMG(int dmgTaken)
    {
        hp -= dmgTaken; // Health - damage

        if(hp <= 0) // If health is 0
        {
            Destroy(this.gameObject); // Destroy this object
        }
    }

    // Collision function
    public void OnCollision(string colliderName, GameObject other)
    {
        if (colliderName == "Range" && other.CompareTag("Player")) // If player is in range
        {
            if (target == null) 
            {
                this.target = other.transform;

                if(movement != null)
                {
                    movement.enabled = false; // Stop moving
                }
                
            }

        }

        if (colliderName == "TakeDmg" && other.CompareTag("Fire")) // If hit by gun projectiles
        {
            TakeDMG(20); // Take 20 damage
            Destroy(other.gameObject); // Destroy projectile
        }

        if (colliderName == "TakeDmg" && other.CompareTag("SwordProjectile")) // If hit by sword projectiles
        {
            TakeDMG(100); // Take 100 damage 
            Destroy(other.gameObject); // Destroy projectile
        }
    }

    // Off collision function
    public void OffCollision(string colliderName, GameObject other)
    {
        if (colliderName == "Range" && other.CompareTag("Player"))
        {
            target = null;

            if (movement != null)
            {
                movement.enabled = true; // Enemy moves
            }
            
        }
    }
}
