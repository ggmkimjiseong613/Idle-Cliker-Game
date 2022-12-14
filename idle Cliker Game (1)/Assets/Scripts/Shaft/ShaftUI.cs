using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ShaftUI : MonoBehaviour
{
    public static Action<Shaft,ShaftUpgrade> OnUpgradeReauest;

    [SerializeField] private TextMeshProUGUI depositGold;
    [SerializeField] private TextMeshProUGUI shaftID;
    [SerializeField] private TextMeshProUGUI shaftLevel;
    [SerializeField] private TextMeshProUGUI newShaftCost;
    [SerializeField] private GameObject newShaftButton;

    private Shaft _shaft;
    private ShaftUpgrade _shaftUpgrade;
    private void Awake()
    {
        _shaft = GetComponent<Shaft>();
        _shaftUpgrade = GetComponent<ShaftUpgrade>();
    }

    void Update()
    {
        depositGold.text = _shaft.ShaftDeposit.CurrentGold.ToString();
    }
    public void AddShaft()
    {
        ShaftManager.Instance.AddShaft();
        newShaftButton.SetActive(false);
    }
    public void OpenUpgradeContainer()
    {
        OnUpgradeReauest?.Invoke(_shaft,_shaftUpgrade);
    }
    public void SetShaftUI(int ID)
    {
        _shaft.ShaftID = ID;
        shaftID.text = (ID + 1).ToString();
    }
    public void SetNewShaftCost(float newCost)
    {
        newShaftCost.text = newCost.ToString();
    }
}
