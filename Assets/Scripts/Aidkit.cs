using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Aidkit : MonoBehaviour
{
    public float healAmount = 50;
   
   private void OnTriggerEnter(Collider other) 
   {
    var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
    if(playerHealth != null)
    {
        playerHealth.AddHealth(healAmount);
        Destroy(gameObject);

    }
    
   }
}
