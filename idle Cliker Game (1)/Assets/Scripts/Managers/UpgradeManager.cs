using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private GameObject upgradeContainer;
    [SerializeField] private Image panelMinerImage;
    [SerializeField] private TextMeshProUGUI panelTitle;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI nextBoost;

    [Header("Stat Title")]
    [SerializeField] private TextMeshProUGUI stat1Title;
    [SerializeField] private TextMeshProUGUI stat2Title;
    [SerializeField] private TextMeshProUGUI stat3Title;
    [SerializeField] private TextMeshProUGUI stat4Title;

    [Header("Stat Values")]
    [SerializeField] private TextMeshProUGUI stat1CurrentValue;
    [SerializeField] private TextMeshProUGUI stat2CurrentValue;
    [SerializeField] private TextMeshProUGUI stat3CurrentValue;
    [SerializeField] private TextMeshProUGUI stat4CurrentValue;

    [Header("Stat Upgrade Values")]
    [SerializeField] private TextMeshProUGUI stat1UpgradeValue;
    [SerializeField] private TextMeshProUGUI stat2UpgradeValue;
    [SerializeField] private TextMeshProUGUI stat3UpgradeValue;
    [SerializeField] private TextMeshProUGUI stat4UpgradeValue;

    [Header("Stat Icon")]
    [SerializeField] private Image stat1Icon;
    [SerializeField] private Image stat2Icon;
    [SerializeField] private Image stat3Icon;
    [SerializeField] private Image stat4Icon;

    [Header("Panel Info")]
    [SerializeField] private UpgradePanellnfo shaftMinerInfo;

    private Shaft _currentShaft;
    private ShaftUpgrade _currentShaftUpgrade;
    public void OpenCloseUpgradeContainer(bool status)
    {
        upgradeContainer.SetActive(status);
    }

    private void UpdateUpgradeInfo()
    {
        panelTitle.text = shaftMinerInfo.PanelTitle;
        panelMinerImage.sprite = shaftMinerInfo.PanelMinerIcon;

        stat1Title.text = shaftMinerInfo.Stat1Title;
        stat2Title.text = shaftMinerInfo.Stat2Title;
        stat3Title.text = shaftMinerInfo.Stat3Title;
        stat4Title.text = shaftMinerInfo.Stat4Title;

        stat1Icon.sprite = shaftMinerInfo.Stat1Icon;
        stat2Icon.sprite = shaftMinerInfo.Stat2Icon;
        stat3Icon.sprite = shaftMinerInfo.Stat3Icon;
        stat4Icon.sprite = shaftMinerInfo.Stat4Icon;
        
    }

    private void UpdateShaftPanelValues()
    {
        stat1CurrentValue.text = $"{_currentShaft.Miners.Count}";
        stat2CurrentValue.text = $"{_currentShaft.Miners[0].MoveSpeed}";
        stat3CurrentValue.text = $"{_currentShaft.Miners[0].CollectPerSecond}";
        stat4CurrentValue.text = $"{_currentShaft.Miners[0].CollectCapacity}";

        stat1UpgradeValue.text = (_currentShaftUpgrade.CurrentLevel + 1) % 10 == 0 ? " +1 " : " +0 ";

        float minerMoveSpeed = _currentShaft.Miners[0].MoveSpeed;
        float walkSpeedUpgrade = Mathf.Abs(minerMoveSpeed - (minerMoveSpeed * _currentShaftUpgrade.MoveSpeedMultiplier));
        stat2UpgradeValue.text = (_currentShaftUpgrade.CurrentLevel + 1) % 10 == 0 ? $"+{walkSpeedUpgrade}/s" : "+0";

        float minerCollectPerSecond = _currentShaft.Miners[0].CollectPerSecond;
        float collectPerSecondUpgraded = Mathf.Abs(minerCollectPerSecond - (minerCollectPerSecond * _currentShaftUpgrade.CollectPerSecondMultiplier));
        stat3UpgradeValue.text = $"+{collectPerSecondUpgraded}";

        float minerCollectCapacity = _currentShaft.Miners[0].CollectCapacity;
        float collectCapacityUpgraded = Mathf.Abs(minerCollectCapacity - (minerCollectCapacity * _currentShaftUpgrade.CollectCapacityMultiplier));
        stat4UpgradeValue.text = $"+{collectCapacityUpgraded}";
    }
    private void ShaftUpgradeRequest(Shaft selectedShaft, ShaftUpgrade selectedUpgrade)
    {
        _currentShaft = selectedShaft;
        _currentShaftUpgrade = selectedUpgrade;
        UpdateUpgradeInfo();
        UpdateShaftPanelValues();
        OpenCloseUpgradeContainer(true);
    }
    private void OnEnable()
    {
        ShaftUI.OnUpgradeReauest += ShaftUpgradeRequest;
    }
    private void OnDisable()
    {
        ShaftUI.OnUpgradeReauest -= ShaftUpgradeRequest;
    }
}
