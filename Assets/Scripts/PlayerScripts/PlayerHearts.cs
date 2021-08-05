using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHearts : MonoBehaviour
{
    public Animator animator; // Animator

    private Stack<GameObject> lives = new Stack<GameObject>(); // Lives

    [SerializeField]
    private GameObject lifePrefab; // Life prefab

    [SerializeField]
    private Transform lifeParent; // Life transform

    public int livesNum; // Number of lives

    private bool isImmortal = false; // Is the player immortal?

    [SerializeField]
    private float immortalityTime = 2.0f; // Immortality variable

    [SerializeField]
    private GameObject gameOverPanel; // Game over panel

    // Start is called before the first frame update
    void Start()
    {
        InitLives(); // Initialise lives
    }

    // Function to initialise lives
    public void InitLives()
    {
        for (int i = 0; i < 3; i++)
        {
            lives.Push(Instantiate(lifePrefab, lifeParent)); // Instantiate 3 lives

        }

        livesNum = 3; // 3 lives

    }

    // Function to add a life
    public void AddLife()
    {
        if (livesNum < 3) // If lives less than 3
        {
            lives.Push(Instantiate(lifePrefab, lifeParent)); // Add life
            livesNum++; // Add life to the count
        }
    }

    // Function to remove a life
    public void RemoveLife()
    {
        if (livesNum > 0) // If lives are more than 0 
        {
            Destroy(lives.Pop()); // Remove life
            livesNum--; // Remove life from count
            StartCoroutine(nameof(Immortality)); // Imortallity
        }

    }

    // Function to take damage
    public void TakeDMG()
    {
        if (!isImmortal) // If the player is not immortal
        {
            if (livesNum > 1) // If lives are more than one
            {
                RemoveLife(); // Remove a life
            }
            else // If not
            {
                RemoveLife(); // Remove a life
                gameOverPanel.SetActive(true); // Activate game over panel
                Destroy(this.gameObject); // Destroy the player
            }
        }
    }

    // Function to respawn
    private IEnumerator GoRespawn()
    {
        animator.SetBool("Death", true); // Death animation

        RemoveLife(); // Remove a life

        GetComponent<PlayerMovement>().enabled = false; // Disable movement

        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        if (livesNum >= 1) // If player has lives
        {
            animator.SetBool("Death", false); // Death animation stops
            this.gameObject.transform.position = new Vector3(-1, -4, 0); // Reset player's position
            GetComponent<PlayerMovement>().enabled = true; // Enable movement

        }
        else // If no lives left
        {
            gameOverPanel.SetActive(true); // Activate game over panel
            Destroy(this.gameObject); // Destroy player
        }

    }

    // Respawn function
    public void Respawn()
    {
        StartCoroutine(nameof(GoRespawn));

    }

    // Immortality function
    private IEnumerator Immortality()
    {
        isImmortal = true; // Player is immortal
        
        yield return new WaitForSeconds(immortalityTime); // Wait for 2 seconds

        isImmortal = false; // Player not immortal

    }

}
