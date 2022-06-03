using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterScript : MonoBehaviour
{
    [Header("Scripts")]
    public ShopScript shopScript;
    public HealthScript healthBar;

    [Header("Player")]
    [SerializeField]
    Transform player;

    [Header("Monster Statistics")]
    [SerializeField]
    float moveSpeed;
   
    [SerializeField]
    float agroGange;
    [SerializeField]
    private float knockbackTime;
    [SerializeField]
    private float knockbackForce;
    //[SerializeField]
    //GameObject monster;
    //[SerializeField]
    //private float moveX;
    //public int maxHealth = 100;
    private float knockbackLeftTime;

    private int currentMonsterHealth;
    [SerializeField]
    int maxMonsterHealth;

    Rigidbody2D rb;

    void Start()
    {
        currentMonsterHealth = maxMonsterHealth;
        healthBar.SetMaxHealth(maxMonsterHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (knockbackLeftTime > 0)
            knockbackLeftTime -= Time.deltaTime;

        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //print("distToPlayer:" + distToPlayer);
        if (distToPlayer < agroGange && knockbackLeftTime <= 0 && !Input.GetButton("Fire1"))
        {
            GoToPlayer();
        }

        /*if (Input.GetMouseButtonUp(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit && hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }*/
        
    }

    void GoToPlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

    }
    void TakeDamage(int damage)
    {
        currentMonsterHealth -= damage;
        healthBar.SetHealth(currentMonsterHealth);
    }

    void OnMouseDown()
    {
        rb.velocity = Vector3.zero;
        Vector3 direction = (transform.position - player.position).normalized;
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        //Debug.Log(direction);
        knockbackLeftTime = knockbackTime;
        //rb.velocity = Vector3.zero;
        //rb.AddForce(monster.transform.up * 9.0F, ForceMode2D.Impulse);

        //Debug.Log(shopScript.ClickDamage);
        //Debug.Log("Touched");
        TakeDamage(shopScript.ClickDamage);
        Debug.Log(shopScript.ClickDamage);
        if (currentMonsterHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
