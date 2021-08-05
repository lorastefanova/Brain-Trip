using UnityEngine;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField]
    private int hp; // Health

    public HPBar hpBar; // Health bar

    public int dmgTaken; // Damage taken

    [SerializeField]
    private GameObject gameOverPanel; // Game over panel

    // Start is called before the first frame update
    void Start()
    {
        hpBar.SetHP(hp); // Set the health in the health bar
    }

    // Function to take damage
    public void TakeDamage()
    {
        hp -= dmgTaken; // Health - damage
        hpBar.SetHP(hp); // Set the current health

        if (hp <= 0) // If the health is 0
        {
            Die(); // Player dies
        }
    }

    // Death function
    private void Die()
    {
        Destroy(this.gameObject); // Destroy the player
        Destroy(hpBar.gameObject); // Destroy the health bar
        gameOverPanel.SetActive(true); // Set game over panel active
    }

}
