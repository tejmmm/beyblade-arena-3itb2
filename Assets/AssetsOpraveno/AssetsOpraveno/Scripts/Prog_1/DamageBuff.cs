using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuff : Buff
{
    //Znovu ti dekuji za to TODO
    private ISetBuff _vlastnosti;

    protected override void ApplyBuff()
    {
        this._vlastnosti.SetBuff(buffPower);
        Timer(); //proc je tu Timer, ale ve speed buffu neni?
    }

    protected override void Timer()
    {
        base.Timer();
        this._vlastnosti.SetBuff(1 / buffPower);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ISetBuff>(out ISetBuff vl))
        {
            this._vlastnosti = vl;
            ApplyBuff();
            Destroy(this);
        }
    }
}