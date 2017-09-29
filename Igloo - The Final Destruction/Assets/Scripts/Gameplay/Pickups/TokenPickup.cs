using UnityEngine;

public class TokenPickup : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelManager.Instance().AddToken(value);
            Destroy(gameObject);
        }
    }
}
