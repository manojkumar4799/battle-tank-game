using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankServices : MonoBehaviour
{
    [SerializeField] TankView tankPrefab;
    [SerializeField] int tankSpeed;
    [SerializeField] float rotationSpeed;

    private void Start()
    {
        CreateTank();
    }
    private void CreateTank()
    {
        TankModel tankModel = new TankModel(tankSpeed, rotationSpeed);
        new TankController(tankPrefab,tankModel);
    }
   
}
