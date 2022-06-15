using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankServices : MonoBehaviour
{
    public TankScriptableObjectList tankList;
    private int tankTypeIndex;

    private void Start()
    {
        tankTypeIndex = Random.Range(0, tankList.tankList.Count);
        CreateTank();
    }
    private void CreateTank()
    {
        new TankController(tankList.tankList[tankTypeIndex]);
    }
   
}
