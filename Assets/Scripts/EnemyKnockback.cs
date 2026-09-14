using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    public Rigidbody2D rb;
    public EnemyMovement movement;

    public void Knockback(Transform player, float knockbackForce, float knockbackTime, float stunTime)
    {
        movement.ChangeState(EnemyState.Knockbacking);
        StartCoroutine(StunTimer(knockbackTime, stunTime));
        Vector2 direction = (transform.position - player.position).normalized;
        rb.velocity = direction * knockbackForce;
    }

    IEnumerator StunTimer(float knockbackTime, float stunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        movement.ChangeState(EnemyState.Idle);
    }
}
