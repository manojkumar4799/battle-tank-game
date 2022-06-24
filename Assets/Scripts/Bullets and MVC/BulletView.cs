using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public BulletContoller bulletController;
  
    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(bulletController.GetBulletDamage(), bulletController.myControllerTankType);
        }
        Destroy(gameObject);
    }
   
}
