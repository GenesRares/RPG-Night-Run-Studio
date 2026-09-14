using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpManager : MonoBehaviour
{
    public float currentExp = 0;
    public float maxExp = 10;
    public float level = 0;
    public float multiplyer = 1.2f;
    public Slider expBar;
    public TMP_Text expText;
    public Animator anim;

    public void Start()
    {
        UpdateUI();
    }

    private void OnEnable()
    {
        EnemyHealth.OnMonsterDefeated += GainExp;
    }

    private void OnDisable()
    {
        EnemyHealth.OnMonsterDefeated -= GainExp;
    }

    public void GainExp(float amount)
    {
        currentExp = currentExp + amount;
        if (currentExp >= maxExp)
        {
            LevelUp();
            
        }
        UpdateUI();
        
    }

    public void LevelUp()
    {  
        currentExp = currentExp - maxExp;
        level++;
        maxExp = Mathf.RoundToInt(maxExp * multiplyer);
        anim.Play("LevelChange");

    }

    public void UpdateUI()
    {
        expBar.value = currentExp;
        expBar.maxValue = maxExp;
        expText.text = "Level: " + level;
    }
}
