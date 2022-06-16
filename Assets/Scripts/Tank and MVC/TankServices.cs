using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankServices : GenericSingleton<TankServices>
{
    public TankScriptableObjectList tankListHolder;
    private int tankTypeIndex;

    private void Start()
    {
        tankTypeIndex = Random.Range(0, tankListHolder.tankList.Count);
        CreatePlayerTank();
        CreateEnemyTanks();
    }
    private void CreatePlayerTank()
    {
        new TankController(tankListHolder.tankList[tankTypeIndex]);
    }

    private void CreateEnemyTanks()
    {
        for (int i = 0; i < tankListHolder.tankList.Count; i++)
        {
            if (i == tankTypeIndex)
            {
                continue;
            }
            TankController tankContoller = new TankController(tankListHolder.tankList[i], Tanktype.Enemy);

        }
    }
   
}
