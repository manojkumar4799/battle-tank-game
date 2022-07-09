using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerTankScriptableObject", menuName ="ScriptableObjects/PlayerTankScriptableObject")]
public class PlayerTankScriptableObject : ScriptableObject
{
    public string tankName;
    public int tankSpeed;
    public float rotationSpeed;
    public int playerTankHealth;
    public BulletScriptableObject bulletScriptableObject;
    public PlayerTankview tankPrefab;
}
