using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMiner : BaseMiner
{
    [SerializeField] private Elevator elevator;
    public Vector3 DepositLocation => new Vector3(transform.position.x, elevator.DepositLocation.position.y);
    private int _currentShaftIndex = -1;
    public override void OnClick()
    {
        MoveTONextLocation();
    }
    private void MoveTONextLocation()
    {
        _currentShaftIndex++;
        Shaft currentShaft = ShaftManager.Instance.Shafts[_currentShaftIndex];
        Vector3 shaftDepositPos = currentShaft.DepositLocation.position;
        Vector3 fixedPos = new Vector3(transform.position.x, shaftDepositPos.y);
        MoveMiner(fixedPos);
    }
    protected override void CollectGold()
    {
        if(_currentShaftIndex == ShaftManager.Instance.Shafts.Count - 1)
        {
            ChangeGoal();
            MoveMiner(DepositLocation);
            _currentShaftIndex = -1;
        }
    }
}
