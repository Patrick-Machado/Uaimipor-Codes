using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backPack_Touch : MonoBehaviour
{
    [SerializeField] GameObject Inventory;
    int touchcont; 
    private void OnMouseDown()
    {
        
        if (touchcont < 2)
        {
            touchcont++; Invoke("reseTouchsCounts",0.5f);
        }
        else { touchcont = 0; }
        if (touchcont == 2)
        {
            Inventory.GetComponent<InventoryController>().Main_BackPack_Head.SetActive(true);
            Inventory.GetComponent<InventoryController>().SelfUpdate();
            Inventory.GetComponent<Animator>().SetTrigger("OpenBag");
            Inventory.GetComponent<InventoryController>().Joystick.SetActive(false);
            GameManager_Singleton.Instance.canPlay = false;
            reseTouchsCounts();
        }
    }
    private void reseTouchsCounts()
    {
        touchcont = 0;//Debug.Log("RESETED COUNTS");
    }
}
