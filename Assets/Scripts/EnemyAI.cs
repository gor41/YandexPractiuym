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
    // Start is called before the first frame update
    void Start()
    {
        Companent();
        Tochka();
    }
    void Update()
    {
        
        NoticePlayerUpdate();
        ChaseUpdate();   
        PatrolUpdate();
    }
    private void Companent()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    private void Tochka()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void PatrolUpdate()
    {
        if(_navMeshAgent.remainingDistance == 0 && !_isPlayerNoticed)
        {
            Tochka();
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
}