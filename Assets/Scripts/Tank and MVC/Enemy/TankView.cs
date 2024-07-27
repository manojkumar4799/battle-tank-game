using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class TankView : MonoBehaviour, IDamagable
{
    
    public Transform bulletSpawnAt;

    public ParticleSystem destroyVFX;
    public NavMeshAgent agent;

    [HideInInspector]
    public TankController tankController;
    [HideInInspector]
    public Tanktype tankType;

    TankState currentState;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {                      
        agent = GetComponent<NavMeshAgent>();
        ChangeState(GetComponent<TankPatrolling>());
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

    public async void DestroyTank( )
    {
        this.enabled = false;
        destroyVFX.Play();
        await new WaitForSeconds(1f);
        TankServices.Instance.ReturnTank(tankController);                   
        EventService.Instance.OnEnemyTankDestroy -= DestroyTank;               
        this.gameObject.SetActive(false);
    }
}
