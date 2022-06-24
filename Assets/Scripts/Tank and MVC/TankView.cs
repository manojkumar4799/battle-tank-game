using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class TankView : MonoBehaviour, IDamagable
{
    public Tanktype tankType= Tanktype.Player;
    public Transform bulletSpawnAt;
    public NavMeshAgent agent;

    [HideInInspector]
    public TankController tankController;

    TankState currentState;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChangeState(GetComponent<TankPatrolling>());
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && tankType == Tanktype.Player)
        {
            tankController.CreateBullet();
        }
        tankController.TankMovement();
    }
    

    public void ChangeState(TankState newState)
    {
        if (currentState != null)
        {
            currentState.OnExitState();
        }
        currentState = newState;
        currentState.OnEnterState();

    }   

    public void TakeDamage(int damage, Tanktype otherTankType)
    {
        if (otherTankType != tankType)
        {
            tankController.TakeDamage(damage);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<TankView>()!= null && collision.gameObject.GetComponent<TankView>().tankType != tankType)
        {
            tankController.EnemyCollison();
        }
        
    }

    public async void DestroyTank(ParticleSystem VFX)
    {
        this.enabled = false;
        Instantiate(VFX, transform.position, Quaternion.identity);
        await new WaitForSeconds(1f);
        DestroyImmediate(VFX,true);
        Destroy(gameObject);
    }
}
