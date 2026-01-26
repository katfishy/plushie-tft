using UnityEngine;
using System;
using System.Collections.Generic;
using Unit;

public class Squidge : Unit
{
    [SerializeField] private readonly string unitName = "Squidge";
    private readonly string[] traits = ["Katie's", "Ocean", "Secretly Evil"];

    protected override Start()
    {
        maxHPArray = [100, 150, 200];
        attackDamageArray = [5, 10, 15];
        attackSpeedArray = [0.3, 0.5, 0.7];

        base.Start();
    }
    


}

