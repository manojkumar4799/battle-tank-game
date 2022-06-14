using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    [HideInInspector]
    public TankController tankController;

    private void Update()
    {
        tankController.TankMovement();
    }
    //public TankController tankController;
    //private void Start()
    //{

    //}

    //private void Update()
    //{
    //   tankController.tankmovement();
    //}

}
