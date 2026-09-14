using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public Transform attackPoint;
    public float weaponRange;
    public LayerMask playerLayer;
    public float knockForce;
    public float stunTime;

    

    private void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);
        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().ModifyHealth( - damage);
            hits[0].GetComponent<PlayerMovement>().Knockback(transform, knockForce, stunTime);
        }
    }
}
