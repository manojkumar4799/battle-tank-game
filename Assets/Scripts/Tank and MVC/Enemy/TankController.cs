using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController 
{
    TankModel tankModel;
    TankView tankPrefab;
    bool isBulletFired = true;

   
    public TankController(TankScriptableObject tankScriptableObject, Tanktype tankType)
    {        
        CreateEnemyTank(tankScriptableObject, tankType);
    }

    public void CreateEnemyTank(TankScriptableObject tankScriptableObject, Tanktype tankType)
    {

        this.tankModel = new TankModel(tankScriptableObject);
        this.tankPrefab = GameObject.Instantiate<TankView>(tankModel.tankScriptableObject.tankPrefab);
        tankPrefab.tankType = tankType;
        tankPrefab.tankController = this;

    }



    public async void CreateBullet()
    {
        if (isBulletFired)
        {
            isBulletFired = false;
            new BulletContoller(tankModel.tankScriptableObject.bulletScriptableObject, tankPrefab.bulletSpawnAt, tankPrefab.tankType);
            await new WaitForSeconds(2f);
            isBulletFired = true;
        }
       
    }


    public void TakeDamage(int damage)
    {  
        tankModel.tankHealth-=damage;
        Debug.Log(tankModel.tankScriptableObject.tankName + " health is: " + tankModel.tankHealth);
        if (tankModel.tankHealth <= 0)
        {
            EventService.Instance.OnEnemyTankDestroy += tankPrefab.DestroyTank;
            EventService.Instance.InvokeOnTankDestroy();
        }
    }

    public void EnableTankPrefabGameObject()
    {
        tankPrefab.gameObject.SetActive(true);
        tankModel.tankHealth = 100;
    }

    public void EnemyCollison()
    {        
          //Vector3 targetAngle = Quaternion.(tankPrefab.transform.rotation.x, tankPrefab.transform.rotation.y + 30, tankPrefab.transform.rotation.z);
          //tankPrefab.transform.rotation = Quaternion.Slerp(tankPrefab.transform.rotation, targetAngle, tankModel.tankScriptableObject.rotationSpeed);
          tankPrefab.transform.Rotate(0, 70, 0);
        
    }

}
