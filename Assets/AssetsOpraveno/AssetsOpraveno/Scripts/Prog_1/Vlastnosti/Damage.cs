using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Vlastnost
{
    private double damage;

    private void Start()
    {
        damage = this.specStat;
    }

    public double GetStat => damage;

    public void ApplyBuff(double buff)
    {
        damage *= buff;
    }
}