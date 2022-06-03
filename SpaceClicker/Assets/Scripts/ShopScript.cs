using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopScript : MonoBehaviour
{

    public PlayerScript playerScript;

    [Header("Player Statistics")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI armorText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI damageText;
    [SerializeField] int Money;
    [SerializeField] int Armor;
    [SerializeField] int HP;

    [HideInInspector]
    [SerializeField] int guntest = 0;
    [HideInInspector]
    [SerializeField] int shotguntest = 0;
    [HideInInspector]
    [SerializeField] int pptest = 0;
    [HideInInspector]
    [SerializeField] int machtest = 0; 

    [Header("Buttons in Shop")]
    public Button buttonGun;
    public Button buttonShotgun;
    public Button buttonTommygun;
    public Button buttonMachinegun;

    public TMP_Text gunPrice;
    public TMP_Text shotgunPrice;
    public TMP_Text tommygunPrice;
    public TMP_Text machinegunPrice;
    
    [HideInInspector]
    public int ClickDamage;
    
    public int[] CostInt;

    void Start()
    {
        gunPrice.text = CostInt[0] + "$";
        shotgunPrice.text = CostInt[1] + "$";
        tommygunPrice.text = CostInt[2] + "$";
        machinegunPrice.text = CostInt[3] + "$";
    }

    void Update()
    {
        moneyText.text = "Money: "+ Money + "$";
        armorText.text = "Armor: " + Armor + "/50";
        healthText.text = "HP:" + HP + "/100";
        damageText.text = "Damage: " + ClickDamage;
        
    }


    public void OnClickBuyGun()
    {

        if (Money >= CostInt[0] && guntest < 1)
        {

            Money -= CostInt[0];
            ClickDamage = 15;
            gunPrice.text = "owned";
            guntest++;
        }
        else
        {
            Debug.Log("You can't buy this item twice");
        }

    }

    public void OnClickBuyShotGun()
    {
        if (Money >= CostInt[1] && shotguntest < 1)
        {
            Money -= CostInt[1];
            ClickDamage = 25;
            shotgunPrice.text = "owned";
            shotguntest++;
        }
        else
        {
            Debug.Log("You can't buy this item twice");
        }
    }

    public void OnClickBuyPP()
    {
        if (Money >= CostInt[2] && pptest < 1)
        {
            Money -= CostInt[2];
            ClickDamage = 50;
            tommygunPrice.text = "owned";
            pptest++;
        }
        else
        {
            Debug.Log("You can't buy this item twice");
        }
    }

    public void OnClickBuyMachine()
    {
        if (Money >= CostInt[3] && machtest < 1)
        {
            Money -= CostInt[3];
            ClickDamage = 100;
            machinegunPrice.text = "owned";
            machtest++;
        }
        else
        {
            Debug.Log("You can't buy this item twice");
        }
    }

    public void OnClickBuyHealth()
    {
        if (Money >= CostInt[0] && HP < 100)
        {
            Money -= CostInt[0];
            HP = 100;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void OnClickBuyArmor()
    {
        if (Money >= CostInt[2] && Armor < 50)
        {
            Money -= CostInt[2];
            Armor = 50;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }




}
