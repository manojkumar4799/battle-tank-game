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
    //[SerializeField] TankView tankPrebaf;
    //[SerializeField] Transform spawnPoint;
    //[SerializeField] int tankSpeed;
    //[SerializeField] float tankHealth;
    //[SerializeField] float rotationSpeed;

    // Start is called before the first frame update
    //void Start()
    //{
    //    CreateTank();
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //public void CreateTank()
    //{
    //    TankModel tankModel = new TankModel(tankSpeed, tankHealth, rotationSpeed); ;
    //   TankController tankcontroller =new TankController(tankModel,tankPrebaf,spawnPoint);
        
    //}
}
