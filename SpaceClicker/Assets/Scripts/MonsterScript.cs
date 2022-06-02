using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public ShopScript shopScript;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    Transform player;
    [SerializeField]
    float agroGange;
    [SerializeField]
    GameObject monster;
    [SerializeField]
    float moveX;
    

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

    void OnMouseDown()
    {
        //var direction = (player.position - transform.position).normalized;
        //rb.AddForce(direction * 100000000, ForceMode2D.Impulse);
        //rb.velocity = Vector3.zero;
        //rb.AddForce(monster.transform.up * 9.0F, ForceMode2D.Impulse);

        
        Debug.Log("Touched");
        TakeDamage(15);
        if (currentHealth < 0)
        {
            Destroy(monster);
        }
    }

    private void FixedUpdate()
    {
        
    }

}
