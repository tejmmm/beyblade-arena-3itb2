using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : Vlastnost
{
    private double stamina;

    private void Start()
    {
        this.stamina = this.specStat;
    }

    public double GetStat => stamina;

    public void DecreaseStamina(double amount)
    {
        if (amount >= this.stamina)
        {
            this.stamina = 0;
        }
        else if (amount >= 0)
        {
            this.stamina -= amount;
        }
    }

    public void SetStamina(double amount)
    {
        if (amount >= 0 && amount <= this.specStat)
        {
            this.stamina = amount;
        }
    }

    public void SetMaxStamina(double amount)
    {
        if (amount > 0)
        {
            this.specStat = amount;
        }
    }

    public float GetPercentOfStaminaLeft()
    {
        return (float)(this.stamina / this.specStat);
    }
}