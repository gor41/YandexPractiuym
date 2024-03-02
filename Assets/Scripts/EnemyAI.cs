using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{   
    public List<Transform> patrolPoints;
    public PlayerController player;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    public float viewAngle;
    public float damage = 30;
    private PlayerHealth _playerHealth;
    void Start()
    {
        Companent();
        Tochka();
    }
    void Update()
    {
        AttackUpdate();
        NoticePlayerUpdate();
        ChaseUpdate();   
        PatrolUpdate();
    }
    private void Companent()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }
    
    private void Tochka()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void PatrolUpdate()
    {
        if(!_isPlayerNoticed)
        {
         if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
         {
            Tochka();
         }
        }

    }
    private void NoticePlayerUpdate()
    {
    var diretion = player.transform.position - transform.position;
    _isPlayerNoticed = false;
    if(Vector3.Angle(transform.forward,diretion) <viewAngle)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position + Vector3.up,diretion,out hit))
        {
            if(hit.collider.gameObject == player.gameObject)
            {
                _isPlayerNoticed = true;                

            }
           
        }
   
    }
}
private void ChaseUpdate()
{
    if(_isPlayerNoticed)
    {
        _navMeshAgent.destination = player.transform.position;
    }

}
private void AttackUpdate()
{
    if(_isPlayerNoticed)
    {
        if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _playerHealth.DealDamage(damage * Time.deltaTime);
        }
    }

}
}