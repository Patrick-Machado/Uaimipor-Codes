using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubepositionfixer : MonoBehaviour
{
    public Transform cubereference;
    void FixedUpdate()
    {
        this.gameObject.transform.position = cubereference.transform.position;//new Vector3(-9.32f, 5.59f, 33.16f);
    }
}
