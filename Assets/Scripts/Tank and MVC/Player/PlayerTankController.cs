using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController 
{
    PlayerTankview playerTankPrefab;
    PlayerTankModel playerTankModel;

    bool isBulletFired=false;
    public PlayerTankController(PlayerTankScriptableObject playerTankscriptableObject)
    {
        playerTankModel = new PlayerTankModel(playerTankscriptableObject);
        playerTankPrefab = GameObject.Instantiate<PlayerTankview>(playerTankscriptableObject.tankPrefab);
        TankServices.Instance.playerTank = playerTankPrefab;
        playerTankPrefab.playerTankController = this;
        SetupCamera();
    }

    void SetupCamera()
    {
        GameObject cam = GameObject.Find("Camera");
        cam.transform.SetParent(playerTankPrefab.transform);
        cam.transform.position = new Vector3(playerTankPrefab.transform.position.x,
                                             playerTankPrefab.transform.position.y+5,
                                             playerTankPrefab.transform.position.z - 7);
    }


    public void PlayerTankMovement(float verticalAxisInput, float horizontalAxisInput)
    {
        float forward = verticalAxisInput * playerTankModel.tankSpeed * Time.deltaTime;
        float rotation = horizontalAxisInput * playerTankModel.rotationSpeed * Time.deltaTime;
        playerTankPrefab.transform.Translate(0, 0, forward);
        playerTankPrefab.transform.Rotate(0, rotation, 0);
    }

    public async void CreateBullet()
    {
        if (!isBulletFired)
        {
            isBulletFired = true;
            new BulletContoller(playerTankModel.bulletScriptableObject, playerTankPrefab.bulletSpawnAt, Tanktype.Player);
            await new WaitForSeconds(1.5f);
            isBulletFired = false;
            TankServices.Instance.NumofbulletsFired++;
        }
    }

    public void TakeDamage(int damage)
    {  
        playerTankModel.playerTankhealth-=damage;
        Debug.Log(playerTankModel.tankName + " health is: " + playerTankModel.playerTankhealth);
        if (playerTankModel.playerTankhealth <= 0)
        {
            playerTankPrefab.PlayerTankDestory();
        }
    }



}
