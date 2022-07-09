using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public TankScriptableObject tankScriptableObject;
    public int tankHealth;    

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        this.tankScriptableObject = tankScriptableObject;
        tankHealth = this.tankScriptableObject.health;

    }
}
