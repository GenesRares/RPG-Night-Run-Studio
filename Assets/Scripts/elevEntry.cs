using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class elevEntry : MonoBehaviour
{
    public Collider2D[] collisions;
    public Collider2D[] barriers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D collider in collisions)
            {
                collider.enabled = false;
            }
            foreach (Collider2D barrier in barriers)
            {
                barrier.enabled = true;
            }
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
        }
        
    }
}
