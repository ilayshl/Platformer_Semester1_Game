using UnityEngine;

public class BackwardsDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(collision.gameObject);
    }
}
