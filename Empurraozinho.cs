using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empurraozinho : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<JoystickPlayerExample>().speed = 25f;Debug.Log("IN");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<JoystickPlayerExample>().speed = 20f; Debug.Log("OUT");
        }
    }
}
