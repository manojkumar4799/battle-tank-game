using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public int tankSpeed;
    public float rotationSpeed;

    public TankModel(int speed, float rotationSpeed)
    {
        tankSpeed = speed;
        this.rotationSpeed = rotationSpeed;

    }
}
