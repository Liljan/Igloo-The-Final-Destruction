using UnityEngine;

public class LivesPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelManager.Instance().AddLife();
            Destroy(gameObject);
        }
    }
}
