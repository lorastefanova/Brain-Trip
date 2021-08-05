using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance; // Score scipt instance
    public int score = 0; // Score variable
    
    private void Awake()
    {
        if (instance == null) // If there is no instance
        {
            instance = this; // This is the instance
        }
        else // If there is another one
        {
            Destroy(gameObject); // Destroy it
        }

        DontDestroyOnLoad(gameObject); // Do not destroy this onject when loading a new scene
    }

}
