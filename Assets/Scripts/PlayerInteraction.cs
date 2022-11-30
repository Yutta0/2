using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private float health = 1f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            Die();
        }
    }
    private void Die()
    {
        SceneManager.LoadScene(0);
    }
}

