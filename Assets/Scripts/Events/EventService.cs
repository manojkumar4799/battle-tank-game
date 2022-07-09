using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventService : GenericSingleton<EventService>
{
    public event Action<int> bulletsFired;
    public event Action  OnEnemyTankDestroy;  

    public void InvokeOnTankDestroy()
    {
        OnEnemyTankDestroy?.Invoke();
    }

    public void InvokeOnBulletHIt(int numOfBullets)
    {
        bulletsFired?.Invoke(numOfBullets);
    }
   
}