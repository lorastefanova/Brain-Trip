using UnityEngine;

public class CamFollowX : MonoBehaviour
{

    public GameObject player; // The player
    public CamFollowX cam;  // The camera

    void LateUpdate()
    {
        if (player != null) // If there is a player
        {
            transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z); // Follow only on the x axis

        }
        else // If not
        {
            cam.enabled = false; // Turn off the camera script
        }
    }
}