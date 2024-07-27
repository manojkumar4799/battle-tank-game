using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : GenericSingleton<UI>
{
    public GameObject EnemyDestroyAchievementMessage;
    public GameObject PlayerTankDeathUI;

    public TextMeshProUGUI TankAchivementMessage;

    public GameObject BulletsFiredAchivement;
    public TextMeshProUGUI BulletsFiredMessage;

    private void Start()
    {
        EventService.Instance.bulletsFired += ShowBulletsAchievement;
    }
    public async void ShowKillAchivement(int numOfTanks)
    {
        EnemyDestroyAchievementMessage.SetActive(true);
        TankAchivementMessage.text = "Achievement: " + numOfTanks + " kills";
        await new WaitForSeconds(3f);
        EnemyDestroyAchievementMessage.SetActive(false);
    }

    public async void ShowBulletsAchievement(int numOfBullets)
    {
        BulletsFiredAchivement.SetActive(true);
        BulletsFiredMessage.text = "Achievement: " + numOfBullets + "bullets fired";
        await new WaitForSeconds(3f);
        BulletsFiredAchivement.SetActive(false);
    }


    public async void OnPlayerTankDestory()
    {
        PlayerTankDeathUI.SetActive(true);
        await new WaitForSeconds(1.2f);
        Time.timeScale = 0f;
    }


    
}
