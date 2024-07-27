using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerTankview : MonoBehaviour,IDamagable
{
    [HideInInspector]
    public PlayerTankController playerTankController;
    public Transform bulletSpawnAt;
    public ParticleSystem destroyVFX;

    public GameObject playerDeathUI;

    private void Awake()
    {
        playerDeathUI = GameObject.Find("DeathUI");
        playerDeathUI.SetActive(false);
    }
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical1");
        float horizontalInput = Input.GetAxis("Horizontal1");
        playerTankController.PlayerTankMovement(verticalInput, horizontalInput);
        if (Input.GetMouseButtonDown(0))
        {
            playerTankController.CreateBullet();
        }
    }

    public void TakeDamage(int damage, Tanktype otherTankType)
    {
        playerTankController.TakeDamage(damage);
    }

    public void PlayerTankDestory()
    {
        playerDeathUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
