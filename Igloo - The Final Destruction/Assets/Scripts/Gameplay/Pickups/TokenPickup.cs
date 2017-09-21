using UnityEngine;

public class TokenPickup : MonoBehaviour
{
    private LevelManager levelManager;
    public int value;

    private void Awake()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelManager.AddToken(value);
            Destroy(gameObject);
        }
    }
}
