using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Master : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

        int i = 0;
        foreach(Transform npcobj in transform)
        {
            //Debug.Log("Named: " + i);
            npcobj.transform.gameObject.GetComponentInChildren<Fala_NPC>().SetID(i);
            i++;
        }
    }


}
