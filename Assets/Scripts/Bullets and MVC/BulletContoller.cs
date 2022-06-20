using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContoller 
{
    BulletModel bulletModel;
    BulletView bulletPrefab;
    public BulletContoller(BulletScriptableObject bulletScritableObject, Transform bulletPos)
    {
        bulletModel = new BulletModel(bulletScritableObject);
        bulletPrefab = GameObject.Instantiate<BulletView>(bulletModel.bulletScriptableObject.bulletPrefab,bulletPos.position,bulletPos.rotation);
        bulletPrefab.bulletController = this;
        FireBullet();
    }

    public void FireBullet()
    {
        Vector3 bulletDirection = bulletPrefab.transform.forward;
        bulletPrefab.GetComponent<Rigidbody>().AddForce(bulletDirection* Time.deltaTime *bulletModel.bulletScriptableObject.bulletSpeed);
    }

    public int GetBulletDamage()
    {
        return bulletModel.bulletScriptableObject.bulletDamage;
    }
}
