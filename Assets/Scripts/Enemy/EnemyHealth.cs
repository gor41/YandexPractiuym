using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator EnemyAnimator;
    public PlayerProgress playerProgress;
    public float damage = 10;
    public Explosion explosionPrefab;
    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("FireBall"))
        {
            DealDamageEnemy(damage);
        }
    }
    public bool IsAlive()
    {
        return value > 0;
    }
    public void DealDamageEnemy(float damage)
    {
        value -= damage;
        FindObjectOfType<PlayerProgress>().AddExperience(damage);
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
        MobBoom();
    }

    private void MobBoom()
    {
        if (explosionPrefab == null) return;
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
}
