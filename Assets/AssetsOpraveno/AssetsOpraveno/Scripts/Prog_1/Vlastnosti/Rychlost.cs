using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rychlost : Vlastnost
{
    private double speed;

    private void Start()
    {
        speed = this.specStat;
    }

    public double GetStat => speed;

    public void CalcAndSetSpeed(Stamina stamina)
    {
        speed = this.specStat - this.specStat / Math.Max(stamina.GetStat, 1);
    }
}