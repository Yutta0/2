using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    private float health = 1f;
    private float damage = 0.25f;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            other.GetComponent<PlayerInteraction>().TakeDamage(damage);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
