using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int exp = 5;
    public delegate void MonsterDefeated(float exp);
    public static event MonsterDefeated OnMonsterDefeated;

    public float currentHealth;
    public float maxHealth = 3;
    

    void Start()
    {
        currentHealth = maxHealth;
    }

    
    public void ChangeHealth(float amount)
    {
        maxHealth = maxHealth + amount;
        
        if (maxHealth <= 0)
        {
            OnMonsterDefeated(exp);
            Destroy(gameObject);
            
        }
    }
}
