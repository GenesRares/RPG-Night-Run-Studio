using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.XR;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;//
    private Transform player;//
    public float speed = 3;//
    public Animator anim;//
    public float range;
    private float facing = -1;//
    private EnemyState enemyState;//
    public float cooldown = 2;
    public float timer = 2;
    public float detectionRange;
    public LayerMask playerLayer;
    public Transform detectionPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }

    
    void Update()
    {
        if (enemyState != EnemyState.Knockbacking)
        {
            CheckForPlayer();
            if (cooldown > 0)
            {
                cooldown = cooldown - Time.deltaTime;
            }
            if (enemyState == EnemyState.Chasing)
            {
                if (player.position.x >= transform.position.x && facing < 0 || player.position.x <= transform.position.x && facing > 0)
                {
                    Flip();
                }
                Vector2 direction = (player.position - transform.position).normalized;
                rb.velocity = direction * speed;
            }
            else if (enemyState == EnemyState.Attacking)
            {
                rb.velocity = Vector2.zero;
            }
        }

        
        
    }

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, detectionRange, playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform;
            if (Vector2.Distance(transform.position, player.position) <= range && 0 >= cooldown)
            {
                cooldown = timer;
                ChangeState(EnemyState.Attacking);
            }
            else if (Vector2.Distance(transform.position, player.position) > range && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    private void Flip()
    {
        facing = -1 * facing;
        transform.localScale = new Vector3(facing, transform.localScale.y, transform.localScale.z);
    }

    public void ChangeState(EnemyState newState)
    {
        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("IsIdle", false);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("IsChasing", false);
        }
        else if (enemyState == EnemyState.Attacking)
        {
            anim.SetBool("IsAttacking", false);
        }

        enemyState = newState;

        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("IsIdle", true);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("IsChasing", true);
        }
        else if (enemyState == EnemyState.Attacking)
        {
            anim.SetBool("IsAttacking", true);
        }
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
    Knockbacking,
}
