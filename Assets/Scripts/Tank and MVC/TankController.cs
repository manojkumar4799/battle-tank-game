using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController 
{
    TankModel tankModel;
    TankView tankPrefab;

    public TankController(TankScriptableObject tankScriptableObject)
    {
        CreatePlayerTank(tankScriptableObject);
    }

    private void CreatePlayerTank(TankScriptableObject tankScriptableObject)
    {
        this.tankModel = new TankModel(tankScriptableObject);
        this.tankModel.tankScriptableObject = tankScriptableObject;
        tankPrefab = GameObject.Instantiate<TankView>(tankModel.tankScriptableObject.tankPrefab);
        tankPrefab.tankController = this;
        SetupCamera();
    }

    void SetupCamera()
    {
        GameObject cam = GameObject.Find("Camera");
        cam.transform.SetParent(tankPrefab.transform);
        cam.transform.position = new Vector3(tankPrefab.transform.position.x,
                                             tankPrefab.transform.position.y+5,
                                             tankPrefab.transform.position.z - 7);
    }

    public void TankMovement()
    {
        float forward = Input.GetAxis("Vertical1") *tankModel.tankScriptableObject.tankSpeed*Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal1") * tankModel.tankScriptableObject.rotationSpeed * Time.deltaTime;
        tankPrefab.transform.Translate(0, 0, forward);
        tankPrefab.transform.Rotate(0, rotation, 0);
    }

}
