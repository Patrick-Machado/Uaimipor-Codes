﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rodando : MonoBehaviour
{


    // Update is called once per frame
    void FixedUpdate() => transform.Rotate(new Vector3(0f, 0f, -0.5f)); 
}
