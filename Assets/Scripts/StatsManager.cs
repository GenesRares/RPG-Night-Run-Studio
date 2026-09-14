using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;

    [Header("Combat Stats")]
    public float cooldown;
    public float range;
    public float amount;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;

    [Header("Movement Stats")]
    public float speed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
