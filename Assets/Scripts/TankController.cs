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
        SetupCamera();
    }

    void SetupCamera()
    {
        GameObject cam = GameObject.Find("Camera");
        cam.transform.SetParent(tankPrefab.transform);
        cam.transform.position = new Vector3(tankPrefab.transform.position.x,
                                             tankPrefab.transform.position.y+4,
                                             tankPrefab.transform.position.z - 6);
    }

    public void TankMovement()
    {
        float forward = Input.GetAxis("Vertical1") *tankModel.tankSpeed*Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal1") * tankModel.rotationSpeed * Time.deltaTime;
        tankPrefab.transform.Translate(0, 0, forward);
        tankPrefab.transform.Rotate(0, rotation, 0);
    }

}
