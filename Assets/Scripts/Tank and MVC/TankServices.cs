using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankServices : GenericSingleton<TankServices>
{
    public TankScriptableObjectList enemyTankListHolder;
    public PlayerTankScriptableObject[] playerTankList;
    private int playerIndex;
    [HideInInspector]
    public PlayerTankview playerTank;

    private TankPoolService tankPoolService;
    private int numOfTanksDestroyed = 0;
    public int NumofbulletsFired=0;


    private void Start()
    {
        tankPoolService = GetComponent<TankPoolService>();

        for(int i=0; i < 4; i++)
        {
            tankPoolService.GetItem();
        }

        CreatePlayerTank();
    }
    public void CreatePlayerTank()
    {
        playerIndex = Random.Range(0, playerTankList.Length);
        PlayerTankController playerTankController = new PlayerTankController(playerTankList[playerIndex]);
    }

    public TankController CreateEnemyTank()
    {
        int enemyIndex = Random.Range(0, enemyTankListHolder.tankList.Count);
        TankController tankContoller = new TankController(enemyTankListHolder.tankList[enemyIndex], Tanktype.Enemy);
        return tankContoller;

    }

    private void Update()
    {
        if (NumofbulletsFired % 5 == 0 && NumofbulletsFired!=0)
        {
            EventService.Instance.InvokeOnBulletHIt(NumofbulletsFired);
        }
    }

    public async void ReturnTank(TankController tankController)
    {
        UI.Instance.ShowKillAchivement(++numOfTanksDestroyed);
        tankPoolService.ReturnItemToPool(tankController);
        await new WaitForSeconds(5f);
        TankController tankControllerItem = tankPoolService.GetItem();
        tankControllerItem.EnableTankPrefabGameObject();
    }
   
}
