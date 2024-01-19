using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    protected float duration;
    protected float timeLeft;
    [SerializeField] protected float buffPower;

    protected abstract void ApplyBuff();
    protected virtual void Timer()
    {
        timeLeft = duration;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }

    }
}
