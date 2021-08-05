using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField]
    private float speed; // Speed variable

    [SerializeField]
    private Vector3[] positions; // Positions

    private int index; // Index

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed); // Change position

        if(transform.position == positions[index])
        {
            if(index == positions.Length -1)
            {
                index = 0;
            }
            else
            {
                index++;
            }    
        }
    }
}
