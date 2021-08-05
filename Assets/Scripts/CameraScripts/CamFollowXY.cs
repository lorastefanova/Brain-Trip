using UnityEngine;

public class CamFollowXY : MonoBehaviour
{

    public GameObject player; // The player
    public CamFollowXY cam; // The camera

    private Vector3 offset; // Offset variable

    void Start()
    {
        offset = transform.position - player.transform.position; // Set the camera offset
    }

    void LateUpdate()
    {
        if (player != null) // If there is a player
        {
            transform.position = player.transform.position + offset; // Follow the player 
            
        }
        else // If not
        {
            cam.enabled = false; // Turn the camera script off
        }
    }
}