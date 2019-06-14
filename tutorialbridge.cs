using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialbridge : MonoBehaviour
{
    public simplecollider cube;
    public void ladotoother()
    {
        if (cube.firstPart)
        {
            return;
        }
        cube.tutoLadoPARAtutocima();
    }
    public void cimatoother()
    {
        if (cube.firstPart)
        {
            return;
        }
        cube.tutocimaPARAtutoLado();
    }
}
