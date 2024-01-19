using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vlastnosti : MonoBehaviour, ISetBuff
{
    [SerializeField] private double modifierZtratyStaminyZaCas = 1;
    [SerializeField] private double maxSpeed = 1;
    [SerializeField] private double Damage = 1;
    [SerializeField] private double maxStamina = 1;
    [SerializeField] private double Defense = 0;
    private Rychlost rychlost;
    private Stamina stamina;
    private Defense defense;
    private Damage damage;
    private double buffDamage = 1;

    void Awake()
    {
        if (gameObject.name == "BayBlade")
        {
            Debug.Log(ShopV2.itemBought.rychlostToceni);
            rychlost = this.AddComponent<Rychlost>();
            rychlost.Init(maxSpeed + ShopV2.itemBought.rychlostToceni);
            stamina = this.AddComponent<Stamina>();
            stamina.Init(maxStamina + ShopV2.itemBought.stamina);
            defense = this.AddComponent<Defense>();
            defense.Init(Defense + ShopV2.itemBought.defense);
            damage = this.AddComponent<Damage>();
            damage.Init(Damage + ShopV2.itemBought.damage);
        }
        else
        {
            rychlost = this.AddComponent<Rychlost>();
            rychlost.Init(maxSpeed);
            stamina = this.AddComponent<Stamina>();
            stamina.Init(maxStamina);
            defense = this.AddComponent<Defense>();
            defense.Init(Defense);
            damage = this.AddComponent<Damage>();
            damage.Init(Damage);
        }
        
    }


    public void SetBuff(float buff)
    {
        this.buffDamage *= buff;
    }

    public float GetPercentOfStaminaLeft => stamina.GetPercentOfStaminaLeft();
    public double GetSpeed => rychlost.GetStat;
    public double GetStamina => stamina.GetStat;

    public double GetDefense => defense.GetStat;

    private void Update()
    {
        stamina.DecreaseStamina(Time.deltaTime / (1 + modifierZtratyStaminyZaCas * 4));
        rychlost.CalcAndSetSpeed(stamina);
        StartCoroutine(WaitAndDestroy(1));
    }

    public void ReceiveDamage(double dmg)
    {
        this.stamina.DecreaseStamina(dmg);
    }

    public double CalculateDamage(double defense)
    {
        return this.buffDamage * this.damage.GetStat * (1 - defense);
    }

    protected void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Vlastnosti>(out Vlastnosti vl))
        {
            vl.ReceiveDamage(this.CalculateDamage(vl.GetDefense));
        }
    }

    IEnumerator WaitAndDestroy(float time)
    {
        if (stamina.GetStat <= 0)
        {
            Debug.Log("Stamina: " + stamina.GetStat);
            if (gameObject.name == "BayBlade")
            {
                yield return new WaitForSeconds(time);
                UnlockLevel.Defeat();
            }
            else
            {
                yield return new WaitForSeconds(time);
                UnlockLevel.Victory();
            }
        }
    }
}