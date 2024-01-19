using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class ButtonosScriptos : MonoBehaviour
{
    public void GetItem(int index)
    {
        ItemV2 itemBought = ShopV2.listItems[index];
        int penize = 1000; //Odnìkud dostat prachy
        if (itemBought.cena >= penize)
        {
            //Nahradit item který právì vlastním za ten kterej jsem koupil
            //Kdyžtak pøeparsovat ItemV2 staty na staty gameobjectu
            penize -= (int)itemBought.cena;
        }

    }

    public void EnableOrDisable()
    {
        if (gameObject.active == true)
        {
            gameObject.active = false;
        }
        else
        {
            gameObject.active = true;
        }
    }
}
