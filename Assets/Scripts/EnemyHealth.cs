using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator EnemyAnimator;
    public float damage = 10;
    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("FireBall"))
        {
            DealDamageEnemy(damage);
        }
    }
    public void DealDamageEnemy(float damage)
    {
        value -= damage;
        if(value <= 0)
        {
            OnDeath();
        }
        else
        {
            EnemyAnimator.SetTrigger("Hit");
        }
    } 
    public void OnDeath()
    {
        EnemyAnimator.SetTrigger("Death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
