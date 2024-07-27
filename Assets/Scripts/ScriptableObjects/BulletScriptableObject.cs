using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BulletScriptableObject", menuName ="ScriptableObjects/newBulletScriptableObject")]
public class BulletScriptableObject : ScriptableObject
{
    public string bulletName;
    public int bulletDamage;
    public BulletView bulletPrefab;
    public float bulletSpeed;
    
}
