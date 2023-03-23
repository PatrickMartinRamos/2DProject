using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeheavior : MonoBehaviour
{
    public int health = 100;
    int currentHealth;
    public Animator animator;
    public float delayTime = 1.0f;

    private void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        animator.SetBool("isDead", true);
        Destroy(gameObject, delayTime);
    }
}
