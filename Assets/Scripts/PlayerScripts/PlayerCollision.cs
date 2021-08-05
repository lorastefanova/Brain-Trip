using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject cluePanel; // Panel

    public GameObject gun; // Gun game object

    public GameObject sword; // Sword game object

    // Collision function
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) // If player stands on platform
        {
            this.gameObject.transform.parent = collision.transform; // Parent player with platform
        }

        if (collision.gameObject.CompareTag("Water")) // If player touches water
        {
            FindObjectOfType<AudioManager>().Play("death"); // Play death sound

            GetComponent<PlayerHearts>().Respawn(); // Respawn player
        }
    }

    // Collision exit function
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) // If player is not on platform
        {
            this.gameObject.transform.parent = null; // No parent
        }
    }

    // Trigger function
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Book")) // If player collides with book
        {
            FindObjectOfType<AudioManager>().Play("collect"); // Play collect sound

            Destroy(collision.gameObject); // Destroy the book

            cluePanel.SetActive(true); // Set the panel active
        }

        if (collision.gameObject.CompareTag("Weapon")) // If player collides with weapon
        {
            FindObjectOfType<AudioManager>().Play("collect"); // Play collect sound

            Destroy(collision.gameObject); // Destroy the weapon
            gun.SetActive(true); // Set the gun active
            sword.SetActive(false); // Deactivate sword
        }

        if (collision.gameObject.CompareTag("Sword")) // If player collides with sword
        {
            FindObjectOfType<AudioManager>().Play("collect"); // Play collect sound

            Destroy(collision.gameObject); // Destroy the sword
            sword.SetActive(true); // Activate sword
            gun.SetActive(false); // Deactivate gun
        }

        if (collision.gameObject.CompareTag("BossProjectile")) // If player collides with boss projectile
        {
            FindObjectOfType<AudioManager>().Play("death"); // Play death sound

            GetComponent<PlayerHpBar>().TakeDamage(); // Take damage
            Destroy(collision.gameObject); // Destroy the projectile
        }

        if (collision.gameObject.CompareTag("Danger")) // If player collides with enemy
        {
            FindObjectOfType<AudioManager>().Play("death"); // Play death sound

            GetComponent<PlayerHearts>().TakeDMG(); // Take damage
        }

        if (collision.gameObject.CompareTag("Boss")) // If player collidess with boss
        {
            FindObjectOfType<AudioManager>().Play("death"); // Play death sound

            GetComponent<PlayerHpBar>().TakeDamage(); // Take damage
        }

        if (collision.gameObject.CompareTag("Life")) // If player collides with a heart
        {
            if(GetComponent<PlayerHearts>().livesNum < 3) // If player has less than 3 lives
            {
                FindObjectOfType<AudioManager>().Play("heart"); // Play heart sound

                GetComponent<PlayerHearts>().AddLife(); // Add a life
                Destroy(collision.gameObject); // Destroy the heart
            }
        }

        if (collision.gameObject.CompareTag("Projectile")) // If player collides with projectile
        {
            FindObjectOfType<AudioManager>().Play("death"); // Play death sound

            Destroy(collision.gameObject); // Destroy the projectile
            GetComponent<PlayerHearts>().TakeDMG(); // Take damage

        }
    }
}
