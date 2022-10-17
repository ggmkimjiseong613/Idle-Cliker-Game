using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour
{
    public float CurrentGold { get; set; }

    public bool canCollectGold => CurrentGold > 0;

    public void DepositGold(float amount)
    {
        CurrentGold += amount;
    }
    public void RemoveGold(float amount)
    {
        if(amount <= CurrentGold)
        {
            CurrentGold -= amount;
        }
    }

    public float CollectGold(BaseMiner miner)
    {
        float minerCapcity = miner.CollectCapacity - miner.CurrentGold;
        return EvaluateAmountToCollect(minerCapcity);
    }
    public float EvaluateAmountToCollect(float minerCollectCapcity)
    {
        if(minerCollectCapcity <= CurrentGold)
        {
            return minerCollectCapcity;
        }
        return CurrentGold;
    }
    
}
