using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    
    public TMP_Text healthText;
    public Animator anim;
    public StatsUI statsUI;
    private void Start()
    {
        StatsManager.Instance.currentHealth = StatsManager.Instance.maxHealth;
        healthText.text = "HP: " + StatsManager.Instance.currentHealth + "/" + StatsManager.Instance.maxHealth;
    }
    

    public void ModifyHealth (int damage)
    {
        StatsManager.Instance.amount = StatsManager.Instance.amount + 1;
        statsUI.UpdateDamage();
        StatsManager.Instance.currentHealth = StatsManager.Instance.currentHealth + damage;
        anim.Play("HealthChange");
        healthText.text = "HP: " + StatsManager.Instance.currentHealth + "/" + StatsManager.Instance.maxHealth;
        if (StatsManager.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        
    }

    
}
