using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMiner : BaseMiner
{
    [SerializeField] private Elevator elevator;
    public Vector3 DepositLocation => new Vector3(transform.position.x, elevator.DepositLocation.position.y);
    private int _currentShaftIndex = -1;
    private Deposit _currentShaftDeposit;
    public override void OnClick()
    {
        MoveTONextLocation();
    }
    private void MoveTONextLocation()
    {
        _currentShaftIndex++;
        Shaft currentShaft = ShaftManager.Instance.Shafts[_currentShaftIndex];
        _currentShaftDeposit = currentShaft.ShaftDeposit;
        Vector3 shaftDepositPos = currentShaft.DepositLocation.position;
        Vector3 fixedPos = new Vector3(transform.position.x, shaftDepositPos.y);
        MoveMiner(fixedPos);
    }
    protected override void CollectGold()
    {
        if(_currentShaftIndex == ShaftManager.Instance.Shafts.Count - 1 && !_currentShaftDeposit.canCollectGold)
        {
            ChangeGoal();
            MoveMiner(DepositLocation);
            _currentShaftIndex = -1;
            return;
        }
        float amountToCollect = _currentShaftDeposit.CollectGold(this);
        float coolectTime = amountToCollect / CollectPerSecond;
        StartCoroutine(IECollect(amountToCollect, coolectTime));
    }
    protected override void DepositGold()
    {
        if(CurrentGold <= 0)
        {
            ChangeGoal();
            MoveTONextLocation();
        }
    }
    protected override IEnumerator IECollect(float gold, float collectTime)
    {
        yield return new WaitForSeconds(collectTime);
        if (CurrentGold < CollectCapacity && gold <= (CollectCapacity - CurrentGold))
        {
            CurrentGold += gold;
            _currentShaftDeposit.RemoveGold(gold);
        }
        yield return new WaitForSeconds(0.5f);
        if(CurrentGold < CollectCapacity &&  _currentShaftIndex != ShaftManager.Instance.Shafts.Count - 1)
        {
            MoveTONextLocation();
        }
        else
        {
            ChangeGoal();
            MoveMiner(DepositLocation);
            _currentShaftIndex = -1;
        }
    }
}
