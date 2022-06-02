using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public ShopScript shopScript;
    public GameObject monster;
    public GameObject player;
    public GameObject deathPanel;
    public GameObject currentPanel;
    public GameObject statsPanel;

    public HealthScript healthBar;

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (player == gameObject)
        {
            TakeDamage(5);
            if (currentHealth < 0)
            {
                statsPanel.SetActive(false); ;
                currentPanel.SetActive(false);
                deathPanel.SetActive(true);
            }
            
            //Debug.Log(collision.name);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
