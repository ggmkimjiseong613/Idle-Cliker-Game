using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform depositLocation;
    public Transform DepositLocation => depositLocation;
}
