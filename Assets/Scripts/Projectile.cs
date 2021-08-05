using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed; // Speed variable

    private Vector2 direction; // Direction variable

    [SerializeField]
    private string targetTag; // Target

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Function to set up direction
    public void SetUp(Vector2 direction)
    {
        this.direction = direction;
    }

}
