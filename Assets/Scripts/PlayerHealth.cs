using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public float MaxHealth;
    public UnityEngine.UI.Image image;
    public GameObject gamePlayUI;
    public GameObject gameOverScreen;
    
    public void DealDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            PlayerIsDead();
        }
        image.fillAmount = Health/MaxHealth;   
    }
    private void PlayerIsDead()
    {
        gamePlayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireBallCast>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }
}