using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftManager : Singleton<ShaftManager>
{
    [SerializeField] private Shaft shaftPrefab;
    [SerializeField] private float newShaftYPosition;
    [SerializeField] private float newShaftCost = 5000;
    [SerializeField] private List<Shaft> shafts;

    private int _currentShaftIndex;
    
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
        newshaft.ShaftUI.SetShaftUI(_currentShaftIndex);
        shafts.Add(newshaft);
    }
}
