using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemV2 : MonoBehaviour
{

    

    public GameObject item { get; private set; }
    public double cena { get; private set; }
    public double rychlostToceni { get; private set; }
    public double stamina { get; private set; }
    public double damage { get; private set; }
    public double defense { get; private set; }

    public ItemV2(GameObject item, double[] stats)
    {
        this.item = item;

        cena = stats[0];
        rychlostToceni = stats[1];
        stamina = stats[2];
        damage = stats[3];
        defense = stats[4];
    }
}
