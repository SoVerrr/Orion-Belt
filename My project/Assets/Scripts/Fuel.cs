using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : Movable
{
    static public int fuelBoost = 20;
    void Update()
    {
        Move(speed, bound);
    }
}
