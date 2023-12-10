using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public BuffDataSO buffData;

    private void OnEnable()
    {
        StartMenu();
    }

    public void StartMenu()
    {
        buffData.addSpeed = buffData.addDistance = buffData.addFrequency = buffData.addDamage = 0;
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);*/
    }
}
