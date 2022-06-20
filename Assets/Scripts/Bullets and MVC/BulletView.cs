using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public BulletContoller bulletController;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    void Update()
    {
    }
}
