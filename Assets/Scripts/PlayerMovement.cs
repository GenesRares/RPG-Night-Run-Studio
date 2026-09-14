using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    private int direction = 1;
    private bool isKnockedBack = false;
    public PlayerCombat combat;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            combat.Attack();
        }

        if (isKnockedBack == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            anim.SetFloat("horizontal", horizontal);
            anim.SetFloat("vertical", vertical);

            if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            Vector2 direction = new Vector2(horizontal, vertical);
            if (direction.magnitude > 1)
            {
                direction = direction.normalized;
            }

            rb.velocity = direction * StatsManager.Instance.speed;
        }
    }
    public void Flip()
    {
        direction = -1 * direction;
        transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
    }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.velocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.velocity = Vector2.zero;
        isKnockedBack = false;
    }
}
