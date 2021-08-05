using UnityEngine;

public interface IntColHandler
{
    void OnCollision(string colliderName, GameObject other);

    void OffCollision(string colliderName, GameObject other);
}
