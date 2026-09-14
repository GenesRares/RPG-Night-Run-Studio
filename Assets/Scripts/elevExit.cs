using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevExit : MonoBehaviour
{
    public Collider2D[] colliders;
    public Collider2D[] barriers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D collider in colliders)
            {
                collider.enabled = true;
            }
            foreach (Collider2D barrier in barriers)
            {
                barrier.enabled = false;
            }
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        
    }
}
