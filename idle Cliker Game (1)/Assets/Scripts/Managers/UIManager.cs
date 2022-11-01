using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalGoldText;
    
    private void Update()
    {
        totalGoldText.text = GoldManager.Instance.CurrentGold.ToString();
    }
}
