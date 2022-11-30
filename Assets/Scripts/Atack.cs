using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    private float damage = 0.5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Demon")
        {
            other.GetComponent<EnemyInteraction>().TakeDamage(damage);
        }
    }

    //public void TakeDamage(float amount)
    //{
    //    health -= amount;

    //    if (health <= 0f)
    //    {
    //        Die();
    //    }
    //}
    //void Die()
    //{
    //    Destroy(gameObject);
    //}
}

