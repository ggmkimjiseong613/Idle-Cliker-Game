using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BaseMiner : MonoBehaviour,ICLickable
{
    [Header("Initial Values")]
    [SerializeField] private float initialCollectCapacity;
    [SerializeField] private float initialCollectPerSecond;
    [SerializeField] protected float moveSpeed;
    public float CurrentGold { get; set; }
    public float CollectCapacity { get; set; }
    public float CollectPerSecond { get; set; }
    public bool isTimeToCollect { get; set; }
    public bool MinerCliked { get; set; }
    public float MoveSpeed { get; set; }

    SpriteRenderer spriteRenderer;
    protected Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        isTimeToCollect = true;

        CollectCapacity = initialCollectCapacity;
        CollectPerSecond = initialCollectPerSecond;

        MoveSpeed = moveSpeed;
    }

    private void OnMouseDown()
    {
        if (!MinerCliked)
        {
            OnClick();
            MinerCliked = true;
        }
    }
    protected virtual void MoveMiner(Vector3 newPosition)
    {
        transform.DOMove(newPosition, MoveSpeed).SetEase(Ease.Linear).OnComplete((()=> 
        {
            if(isTimeToCollect)
            {
                CollectGold();
            }
            else
            {
                DepositGold();
            }
        })).Play();
    }
    protected virtual void CollectGold()
    {

    }
    protected virtual void DepositGold()
    {

    }
    protected void RotateMiner(int direction)
    {
        if(direction == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            //spriteRenderer.flipX = false;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            //spriteRenderer.flipX = true;
        }
    }
    protected void ChangeGoal()
    {
        isTimeToCollect = !isTimeToCollect;
    }
    protected virtual IEnumerator IECollect(float gold, float collectTime)
    {
        
        yield return null;
    }

    public virtual void OnClick()
    {
        
    }
    protected virtual IEnumerator IEDeposit(float depositTime)
    {
        yield return null;
    }
}
