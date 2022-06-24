using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankState : MonoBehaviour
{
    protected TankView tankPrefab;

    private void Awake()
    {
        tankPrefab = GetComponent<TankView>();
    }
    public virtual void OnEnterState() 
    {
        this.enabled = true;
    }
    public virtual void OnExitState()
    {
        this.enabled = false;
    }
}
