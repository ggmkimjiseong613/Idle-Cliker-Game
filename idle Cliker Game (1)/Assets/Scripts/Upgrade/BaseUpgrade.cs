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

    void Start()
    {
        CurrentLevel = 1;
        UpgradeCost = initialUpgradeCost;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
