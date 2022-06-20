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
        if (collision.gameObject.CompareTag("Bullet"))
        {
            tankController.TakeDamage(collision.gameObject.GetComponent<BulletView>().bulletController.GetBulletDamage());
            //Destroy(collision.gameObject);
        }        
        tankController.EnemyCollison();
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
