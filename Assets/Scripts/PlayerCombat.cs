using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform AttaackPoint;
    public float attackrange = 0.5f;
    public int atkdamage = 20;

    public LayerMask enemyLayers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");

       Collider2D[] hitenemies =  Physics2D.OverlapCircleAll(AttaackPoint.position, attackrange, enemyLayers );

        foreach(Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<EnemyBeheavior>().TakeDamage(atkdamage); 
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttaackPoint.position, attackrange);
    }
}