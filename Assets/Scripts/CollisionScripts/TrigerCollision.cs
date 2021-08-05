using UnityEngine;

public class TrigerCollision : MonoBehaviour
{
    private IntColHandler handler; // Instance to the collision interface

    // Start is called before the first frame update
    void Start()
    {
        handler = GetComponentInParent<IntColHandler>(); // Get the component
    }

    // Function for collision
    private void OnTriggerEnter2D (Collider2D collision)
    {
        handler.OnCollision(gameObject.name, collision.gameObject);
    }

    // Function when the collision ends
    private void OnTriggerExit2D(Collider2D collision)
    {
        handler.OffCollision(gameObject.name, collision.gameObject);
    }
}
