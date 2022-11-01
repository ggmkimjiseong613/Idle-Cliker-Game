using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseMiner : BaseMiner
{
    public Deposit ElevatorDeposit { get; set; }
    public Vector3 ElevatorDepositLocation { get; set; }
    public Vector3 WarehouseLocation { get; set; }

    private int _walkAnimation = Animator.StringToHash("walk");

    protected override void MoveMiner(Vector3 newPosition)
    {
        base.MoveMiner(newPosition);
        _animator.SetBool(_walkAnimation, true);
    }
    public override void OnClick()
    {
        RotateMiner(-1);
        MoveMiner(ElevatorDepositLocation);
    }
}
