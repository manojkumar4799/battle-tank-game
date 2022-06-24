using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankChasing : TankState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Entered chasing state", gameObject);
    }

    private void Update()
    {
        if(tankPrefab.tankType == Tanktype.Enemy)
        {
            tankPrefab.agent.SetDestination(TankServices.Instance.playerTank.gameObject.transform.position);
            if (Vector3.Distance(TankServices.Instance.playerTank.gameObject.transform.position, transform.position) <= tankPrefab.agent.stoppingDistance)
            {
                tankPrefab.ChangeState(GetComponent<TankAttack>());
            }
        }
    }
    public override void OnExitState()
    {
        Debug.Log("Exited chasing state", gameObject);
        base.OnExitState();
    }
}
