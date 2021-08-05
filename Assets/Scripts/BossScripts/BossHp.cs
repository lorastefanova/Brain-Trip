using UnityEngine;

public class BossHp : MonoBehaviour
{
    [SerializeField]
    private int maxHP; // Max health variable

    private int hp; // Health variable

    public bool isInvulnerable; // Is the boss invulnerable?

    public HPBar hpBar; // Instance of the HPBare script

    [SerializeField]
    private GameObject panel; // Panel game object

    public int levelToUnlock = 2; // Next level to be unlocked

    private void Start()
    {
        hp = maxHP; // Set the health to the maximum health
        hpBar.SetHP(hp); // Set the health bar to the current health

    }

    // Function to take damage
    private void TakeDamage(int dmgTaken)
    {

        hp -= dmgTaken; // Health - damage
        hpBar.SetHP(hp); // Set the health bar to the current health

        if (hp <= maxHP/2) // If the health is halved
        {
            GetComponent<Animator>().SetBool("IsEnraged", true); // IsEnraged bool set to true
        }

        if(hp <=0 ) // If the boss has no health
        {
            Die(); // Boss dies
        }
    }

    // Boss death function
    private void Die()
    {
        Destroy(this.gameObject); // Destroys the boss
        Destroy(hpBar.gameObject); // Destrooys the health bar
        panel.SetActive(true); // Sets the panel active
        PlayerPrefs.SetInt("levelUnlocked", levelToUnlock); // Unlocks the next level
    }

    // Function for collision
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire")) // If boss collides with fire
        {
            if (isInvulnerable) // Don't run if the player is invulnnerable
            {
                return;
            }

            TakeDamage(50); // Take 50 damage
            Destroy(collision.gameObject); // Destroy the fire projectile
        }

        if (collision.gameObject.CompareTag("SwordProjectile"))  // If boss collides with sword projectile
        {
            if (isInvulnerable) // Don't run if the player is invulnnerable
            {
                return;
            }

            TakeDamage(150); // Take 150 damage
            Destroy(collision.gameObject); // Destroy the sword projectile
        }
    }
}
