using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUpgrade : MonoBehaviour
{
    [Header("Upgrade")]
    [SerializeField] private float collectCapacityMultiplier = 2;
    [SerializeField] private float collectPerSecondMultiplier = 2;
    [SerializeField] private float moveSpeedMultiplier = 2;

    [Header("Cost")]
    [SerializeField] private float initialUpgradeCost = 600;
    [SerializeField] private float upgradeCostMultiplier = 2;
    
    public int CurrentLevel { get; set; }
    public float UpgradeCost { get; set; }
    public float CollectCapacityMultiplier => collectCapacityMultiplier;
    public float CollectPerSecondMultiplier => collectPerSecondMultiplier;
    public float MoveSpeedMultiplier => moveSpeedMultiplier;

    protected Shaft _shaft;
    void Start()
    {
        _shaft = GetComponent<Shaft>();

        CurrentLevel = 1;
        UpgradeCost = initialUpgradeCost;
    }
    public void Upgrade(int amount)
    {
        if(amount > 0)
        {
            for(int i = 0; i<amount; i++)
            {
                UpgradeCompleted();
                ExecuteUpgrade();
            }
        }
    }
    private void UpgradeCompleted()
    {
        GoldManager.Instance.RemoveGold(UpgradeCost);
        UpgradeCost *= upgradeCostMultiplier;
        CurrentLevel++;
    }
    protected virtual void ExecuteUpgrade()
    {

    }
}
