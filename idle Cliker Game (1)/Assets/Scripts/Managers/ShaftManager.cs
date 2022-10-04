using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftManager : Singleton<ShaftManager>
{
    [SerializeField] private Shaft shaftPrefab;
    [SerializeField] private float newShaftYPosition;
    [SerializeField] private float newShaftCost = 5000;
    [SerializeField] private float newShaftCostMultiplier = 10;
    [SerializeField] private List<Shaft> shafts;

    public float ShaftCost { get; set; }

    private int _currentShaftIndex;

    private void Start()
    {
        ShaftCost = 5000;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            AddShaft();
        }
    }
    public void AddShaft()
    {
        
        Transform lastShaft = shafts[_currentShaftIndex].transform;
        Vector3 newShaftPos = new Vector3(lastShaft.position.x, lastShaft.position.y - newShaftYPosition);
        Shaft newshaft = Instantiate(shaftPrefab, newShaftPos, Quaternion.identity);

        _currentShaftIndex++;
        ShaftCost *= newShaftCostMultiplier;

        newshaft.ShaftUI.SetShaftUI(_currentShaftIndex);
        newshaft.ShaftUI.SetNewShaftCost(ShaftCost);

        shafts.Add(newshaft);
    }
}
