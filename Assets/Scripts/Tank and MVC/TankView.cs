using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class TankView : MonoBehaviour
{
    [HideInInspector]
    public TankController tankController;

    private void Update()
    {
        tankController.TankMovement();
    }   
}
