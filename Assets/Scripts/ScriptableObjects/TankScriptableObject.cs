using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TankScriptableObject", menuName ="ScriptableObjects/TankDataContainer")]
public class TankScriptableObject : ScriptableObject
{
    public string tankName;
    public int tankSpeed;
    public float rotationSpeed;
    public int health;
    public BulletScriptableObject bulletScriptableObject;
    public Tanktype tankType;
    public TankView tankPrefab;
    public ParticleSystem tankExplosionVFX;
}

