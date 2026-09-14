using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public GameObject[] stats;
    private bool isActive = false;

    private void Start()
    {
        UpdateAllStats();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isActive == true)
            {
                GetComponent<CanvasGroup>().alpha = 0;
                isActive = false;
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                GetComponent<CanvasGroup>().alpha = 1;
                isActive = true;
            }
            
        }
        
    }

    public void UpdateDamage()
    {
        stats[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + StatsManager.Instance.amount;
    }

    public void UpdateSpeed()
    {
        stats[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatsManager.Instance.speed;
    }

    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
    }

}
