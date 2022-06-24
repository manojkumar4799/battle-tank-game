using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrolling :TankState
{
   public override void OnEnterState()
   {
        base.OnEnterState();
        Debug.Log("Entered TankPatrolling state", gameObject);
   }
    
   private void Update()
   {
       if(tankPrefab.tankType == Tanktype.Enemy)
       {
           transform.Translate(Vector3.forward * 11 * 0.7f * Time.deltaTime);
           if (Vector3.Distance(TankServices.Instance.playerTank.gameObject.transform.position, transform.position) < 15)
           {
               tankPrefab.ChangeState(GetComponent<TankChasing>());
           }
       }       
        
   }

   public override void OnExitState()
   {
      Debug.Log("Exited TankPatrolling state", gameObject);
      base.OnExitState();
   }
}