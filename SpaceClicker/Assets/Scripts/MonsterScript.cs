using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    Transform player;
    [SerializeField]
    float agroGange;
    [SerializeField]
    GameObject monster;

    public HealthScript healthBar;

    public int maxHealth = 100;
    public int currentHealth;


    Rigidbody2D rb;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //print("distToPlayer:" + distToPlayer);
        if (distToPlayer < agroGange)
        {
            GoToPlayer();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            TakeDamage(15);
            if (currentHealth < 0)
            {
                Destroy(monster);
            }
        }
    }

    void GoToPlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}
