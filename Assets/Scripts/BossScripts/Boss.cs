using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform target; // A target to follow

    // Function to turn to the target
    public void TurnToTarget()
    {
        if (target != null) // If there is a target 
        {
            Vector3 scale = transform.localScale;
            scale.x = target.transform.position.x < transform.position.x ? -1 : 1; // Scale on the x axis is either 1 or -1

            transform.localScale = scale;
        }
    }

}
