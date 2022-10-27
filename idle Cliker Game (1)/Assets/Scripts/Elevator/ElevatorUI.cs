using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ElevatorUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI elevatorDepositGoldText;
    private Elevator _elevator;
    void Start()
    {
        _elevator = GetComponent<Elevator>();
    }
    void Update()
    {
        elevatorDepositGoldText.text = _elevator.ElevatorDeposit.CurrentGold.ToString();
    }
}
