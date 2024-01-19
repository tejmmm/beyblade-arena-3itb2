using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : Buff
{
    //Fakt diky za to TODO
    private ISetBuff _movement;

    protected override void ApplyBuff()
    {
        this._movement.SetBuff(buffPower);
    }
    protected override void Timer()
    {
        base.Timer();
        this._movement.SetBuff(1/buffPower);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ISetBuff>(out ISetBuff mv))
        {
            this._movement = mv;
            ApplyBuff();
            Destroy(this);
        }
    }
}
