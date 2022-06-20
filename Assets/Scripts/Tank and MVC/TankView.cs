using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class TankView : MonoBehaviour
{
    public Tanktype tankType= Tanktype.Player;
    public Transform bulletSpawnAt;

    [HideInInspector]
    public TankController tankController;

    private void Update()
    {
        
        
        if (Input.GetMouseButtonDown(0))
        {
            tankController.CreateBullet();
        }

        tankController.TankMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        tankController.EnemyCollison();
    }
}
