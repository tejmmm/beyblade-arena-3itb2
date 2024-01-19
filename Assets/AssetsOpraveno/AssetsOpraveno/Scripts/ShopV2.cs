using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopV2 : MonoBehaviour
{
    static public ItemV2 itemBought;
    public static List<ItemV2> listItems = new List<ItemV2>();

    [SerializeField] List<GameObject> listPrefab = new List<GameObject>();

    [SerializeField] GameObject panel;
    [SerializeField] GameObject itemPanel;

    private void Awake()
    {
        itemBought = new ItemV2(listPrefab[0], new double[] { 0, 0, 0, 0, 0 });
    }
    private void Start()
    {
        panel.active = false;
        CreateShopItem(10);
    }

    void CreateShopItem(int kolikrat)
    {
        listItems.Clear();
        for (int i = 0; i < kolikrat; i++)
        {
            ItemV2 item = new ItemV2(ReturnCastGameObject(), ReturnStats());
            listItems.Add(item);
        }

        for (int i = 0; i < listItems.Count; i++)
        {
            Debug.Log($"{i}. Item: {listItems[i].item}, Cena: {listItems[i].cena}");
        }
        LoadItemGraphics();
    }

    GameObject ReturnCastGameObject()
    {
        return listPrefab[Random.Range(0, listPrefab.Count)];
    }

    double[] ReturnStats()
    {
        //VYBALANCOVAT!!
        double[] array = new double[5];
        array[0] = Random.Range(1, 100); //money
        array[1] = Random.Range(0, (float)array[0]); //rychlost toceni všecno je max z money
        array[2] = Random.Range(0, (float)array[0]); //stamina 
        array[3] = Random.Range(0, (float)array[0]); //damage
        array[4] = Random.Range(0, (float)array[0]); //defense

        return array;
    }

    void LoadItemGraphics()
    {
        LoadItemGraphics loadScript = new LoadItemGraphics();
        loadScript.Load(panel, itemPanel, listItems);
    }
}
