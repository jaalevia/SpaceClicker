using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL1 : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public MonsterScript scr;
    void Update()
    {
        if (scr.currentMonsterHealth <= 0)
        {

            panel1.SetActive(true);
            panel2.SetActive(false);
            panel3.SetActive(false);

        }
    }
}
