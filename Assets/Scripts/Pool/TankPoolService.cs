using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPoolService : PoolService<TankController>
{
    protected override TankController CreateNewItem()
    {
        return TankServices.Instance.CreateEnemyTank();       
    }

}
