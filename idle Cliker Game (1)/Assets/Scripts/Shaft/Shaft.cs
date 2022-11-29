using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaft : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private ShaftMiner minerPrefab;
    [SerializeField] private Deposit depositPrefab;
    
    [Header("Locations")]
    [SerializeField] private Transform miningLocation;
    [SerializeField] private Transform depositLocation;
    [SerializeField] private Transform depositCreationLocation;

    public int ShaftID { get; set; }
    public Transform MiningLocation => miningLocation;
    public Transform DepositLocation => depositLocation;
    public Deposit ShaftDeposit { get; set; }
    public ShaftUI ShaftUI { get; set; }

    private List<ShaftMiner> _miners = new List<ShaftMiner>();
    public List<ShaftMiner> Miners => _miners;
    private void Awake()
    {
        ShaftUI = GetComponent<ShaftUI>();
    }
    private void Start()
    {
        CreateMiner();
        CreateDeposit();
    }
    public void CreateMiner()
    {
       ShaftMiner newMiner = Instantiate(minerPrefab, depositLocation.position, Quaternion.identity);
        newMiner.CurrentShaft = this;
        newMiner.transform.SetParent(transform);
        _miners.Add(newMiner);
    }
    private void CreateDeposit()
    {
        ShaftDeposit = Instantiate(depositPrefab, depositCreationLocation.position, Quaternion.identity);
        ShaftDeposit.transform.SetParent(transform);
    }
}
