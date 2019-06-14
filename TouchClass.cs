using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchClass : MonoBehaviour
{
    public List<string> Message;
    public bool DestroyOnFinish;

    private void OnMouseDrag()
    {
        Destroy(this.gameObject);
    }
  
}
