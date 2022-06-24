using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : TankState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Entered attacking state: ",gameObject);
    }
    private void Update()
    {
        if(tankPrefab.tankType == Tanktype.Enemy)
        {
            tankPrefab.tankController.CreateBullet();
            if(Vector3.Distance(TankServices.Instance.playerTank.gameObject.transform.position, transform.position) > tankPrefab.agent.stoppingDistance)
            {
                tankPrefab.ChangeState(GetComponent<TankChasing>());
            }
        }
    }

    public override void OnExitState()
    {
        Debug.Log("Exited attacking state", gameObject);
        base.OnExitState();
    }
}
