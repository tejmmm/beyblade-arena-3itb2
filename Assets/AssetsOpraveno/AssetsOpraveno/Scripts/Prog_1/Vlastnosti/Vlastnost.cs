using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vlastnost : MonoBehaviour
{
    protected double specStat;

    public void Init(double stat)
    {
        this.specStat = stat;
    }

    public double GetStat => specStat;
}