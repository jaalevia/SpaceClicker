using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAppleScr : MonoBehaviour
{
    public ShopScript shopScript;
    [SerializeField] GameObject apple;
    public SpawnerScript scr;
    void OnMouseDown()
    {

        scr.appleList.Remove(apple);
        Destroy(apple);
    }
}
