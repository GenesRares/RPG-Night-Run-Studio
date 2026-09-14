using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    
    private float timer = 0;
    
    public LayerMask enemyLayer;
    public Transform point;
    

    void Update()
    {
        timer = timer - Time.deltaTime;
    }
    public void Attack()
    {
        if (timer <= 0)
        {
            anim.SetBool("isAttacking", true);
            timer = StatsManager.Instance.cooldown;
        }   
    }

    public void DealDamage()
    {
        
        Collider2D[] enemies = Physics2D.OverlapCircleAll(point.position, StatsManager.Instance.range, enemyLayer);
        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>().ChangeHealth(-StatsManager.Instance.amount);
            enemies[0].GetComponent<EnemyKnockback>().Knockback(transform, StatsManager.Instance.knockbackForce, StatsManager.Instance.knockbackTime, StatsManager.Instance.stunTime);
        }
    }

    public void EndAttack()
    {
        anim.SetBool("isAttacking", false);
    }

    
}
