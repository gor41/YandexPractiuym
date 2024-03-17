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
    public Animator _animator;
    public bool IsAlive()
    {
        return Health > 0;
    }
    
    public void DealDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            PlayerIsDead();
        }
        image.fillAmount = Health/MaxHealth;   
    }
    public void AddHealth(float amount)
    {
        Health += amount;
        Health = Mathf.Clamp(Health,0,MaxHealth);
        image.fillAmount = Health/MaxHealth;  
        
    }
    private void PlayerIsDead()
    {
        gamePlayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        gameOverScreen.GetComponent<Animator>().SetTrigger("Show");
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireBallCast>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        _animator.SetTrigger("Death");
    }
}
