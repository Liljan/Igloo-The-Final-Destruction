using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;

    private Rigidbody2D rb2d;

    public void Awake()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        rb2d.velocity = new Vector2(speed * Mathf.Cos(angle), speed * Mathf.Sin(angle));

        Debug.Log("Created");
    }

    public void SetSpeed(float s)
    {
        speed = s;
    }

    public void SetDamage(int d)
    {
        damage = d;
    }

    public int GetDamage() { return damage; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.tag.Equals("Player") || other.tag.Equals("PlayerBullet"))
        {
            return;
        }
        */

        if (other.tag.Equals("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);
            Destroy(this.gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
