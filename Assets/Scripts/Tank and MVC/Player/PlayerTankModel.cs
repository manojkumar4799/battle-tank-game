using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankModel 
{
    public string tankName;
    public int tankSpeed;
    public float rotationSpeed;
    public int playerTankhealth;
    public BulletScriptableObject bulletScriptableObject;
    public PlayerTankview tankPrefab;

    public PlayerTankModel(PlayerTankScriptableObject playerTankScriptableObject)
    {
        tankName = playerTankScriptableObject.tankName;
        tankSpeed = playerTankScriptableObject.tankSpeed;
        rotationSpeed = playerTankScriptableObject.rotationSpeed;
        playerTankhealth = playerTankScriptableObject.playerTankHealth;
        bulletScriptableObject = playerTankScriptableObject.bulletScriptableObject;
        tankPrefab = playerTankScriptableObject.tankPrefab;
    }
}
