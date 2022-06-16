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

    public TankController(TankScriptableObject tankScriptableObject, Tanktype tankControl)
    {
        this.tankModel = new TankModel(tankScriptableObject);        
        CreateEnemyTank(tankScriptableObject);
    }

    private void CreatePlayerTank(TankScriptableObject tankScriptableObject)
    {
        this.tankModel = new TankModel(tankScriptableObject);        
        tankPrefab = GameObject.Instantiate<TankView>(tankModel.tankScriptableObject.tankPrefab);        
        tankPrefab.tankController = this;
        SetupCamera();
    }

    public void CreateEnemyTank(TankScriptableObject tankScriptableObject)
    {
        
        this.tankPrefab = GameObject.Instantiate<TankView>(tankModel.tankScriptableObject.tankPrefab);
        tankPrefab.tankType = Tanktype.Enemy;
        tankPrefab.tankController = this;             

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
        if(tankPrefab.tankType== Tanktype.Player)
        {
            float forward = Input.GetAxis("Vertical1") * tankModel.tankScriptableObject.tankSpeed * Time.deltaTime;
            float rotation = Input.GetAxis("Horizontal1") * tankModel.tankScriptableObject.rotationSpeed * Time.deltaTime;
            tankPrefab.transform.Translate(0, 0, forward);
            tankPrefab.transform.Rotate(0, rotation, 0);
        }
        if(tankPrefab.tankType == Tanktype.Enemy)
        {
            EnemyTankMovement();
        }
        
    }

    public void CreateBullet()
    {
        new BulletContoller(tankModel.tankScriptableObject.bulletScriptableObject, tankPrefab.bulletSpawnAt);
    }

    void EnemyTankMovement()
    {
       
        tankPrefab.transform.Translate(Vector3.forward * tankModel.tankScriptableObject.tankSpeed *0.7f * Time.deltaTime);
    }

    public void EnemyCollison()
    {
        if(tankPrefab.tankType == Tanktype.Enemy)
        {
            //Vector3 targetAngle = Quaternion.(tankPrefab.transform.rotation.x, tankPrefab.transform.rotation.y + 30, tankPrefab.transform.rotation.z);
           // tankPrefab.transform.rotation = Quaternion.Slerp(tankPrefab.transform.rotation, targetAngle, tankModel.tankScriptableObject.rotationSpeed);
            tankPrefab.transform.Rotate(0, 70, 0);
        }
    }

}
