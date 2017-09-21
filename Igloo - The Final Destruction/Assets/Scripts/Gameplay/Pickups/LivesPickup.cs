using UnityEngine;

public class LivesPickup : MonoBehaviour
{
    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelManager.AddLife();
            Destroy(gameObject);
        }
    }
}
