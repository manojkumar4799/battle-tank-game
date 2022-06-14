using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController 
{
    TankModel tankModel;
    TankView tankPrefab;
    public TankController(TankView tankPrefab, TankModel tankModel)
    {
        this.tankModel = tankModel;
        this.tankPrefab = GameObject.Instantiate<TankView>(tankPrefab);
        this.tankPrefab.tankController = this;
    }

    public void TankMovement()
    {
        float forward = Input.GetAxis("Vertical1") *tankModel.tankSpeed*Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal1") * tankModel.rotationSpeed * Time.deltaTime;
        tankPrefab.transform.Translate(0, 0, forward);
        tankPrefab.transform.Rotate(0, rotation, 0);
    }
    //public TankModel tankModel { get; }
    //public TankView tankView;
    //public TankController(TankModel tankModel, TankView tankView, Transform spawnPoint)
    //{

    //    this.tankModel = tankModel;
    //    this.tankView = GameObject.Instantiate<TankView>(tankView,spawnPoint.position,Quaternion.identity);
    //    this.tankView.tankController = this;
    //}

    //public void tankmovement()
    //{
    //    float forward = Input.GetAxis("Vertical1") * tankModel.Speed* Time.deltaTime;
    //    float tankroation = Input.GetAxis("Horizontal1")*Time.deltaTime;
    //    tankView.transform.Translate(0, 0, forward);
    //    tankView.transform.Rotate(0, tankroation * tankModel.RotationSpeed, 0);

    //}

}
