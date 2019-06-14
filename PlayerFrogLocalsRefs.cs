using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrogLocalsRefs : MonoBehaviour
{
    public Transform[] Locais = new Transform[4];
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            /*foreach(SaveLoad.Item i in SaveLoad.inventoryData)
            {
                Debug.Log(i.NAME_PT + " "+ i.AMOUNT);
            }*/
            GameManager_Singleton.Instance.ClearWater();
            Debug.Log(GameManager_Singleton.Instance.temporarayItensCount + " TemporaryItensCount");
            Debug.Log(GameManager_Singleton.Instance.temporarySolutionsSaverCount + " TempSolutionSaver");
        }
    }
}
