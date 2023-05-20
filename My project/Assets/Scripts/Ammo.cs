using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Movable
{
    static public int ammoBoost = 10;
    void Update()
    {
        Move(speed, bound);              
    }
}
