using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private WarehouseMiner minerPrefab;

    [Header("Extras")]
    [SerializeField] private Deposit elevatorDeposit;
    [SerializeField] private Transform elevatorDepositLocation;
    [SerializeField] private Transform warehouseDepositLocation;
    void Start()
    {
        AddMiner();
    }

    private void AddMiner()
    {
        WarehouseMiner newMiner = Instantiate(minerPrefab, warehouseDepositLocation.position, Quaternion.identity);
        newMiner.ElevatorDeposit = elevatorDeposit;
        newMiner.ElevatorDepositLocation = new Vector3(elevatorDepositLocation.position.x, warehouseDepositLocation.position.y);
        newMiner.WarehouseLocation = new Vector3(warehouseDepositLocation.position.x, warehouseDepositLocation.position.y);

    }
}
