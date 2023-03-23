using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}