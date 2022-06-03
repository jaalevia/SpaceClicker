using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public PlayerScript scr;
    public Slider slider;

    public void SetMaxHealth(int health)
    {

        slider.maxValue = health;
        slider.value = health;
    
    }

    private void Update()
    {
        slider.value = scr.currentHealth;
    }
    public void SetHealth(int health)
    {
        
        slider.value = health;
    }

    
}
