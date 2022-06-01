using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject monster;
    public GameObject player;
    public GameObject deathPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player == gameObject)
        {
            deathPanel.SetActive(true);
            //Debug.Log(collision.name);
        }
    }
}
