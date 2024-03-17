using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> _spawnerPoints;
    public List<Transform> patrolPoints;
    private List<EnemyAI> _enemies;

    public int enemiesMaxCount =  5;
    public float delay = 5;
    public float IncreadeEnemiesDelay = 15;
    private float _timeLastSpawned;


    public EnemyAI enemyAIPrefabs;
    public PlayerController player;

     private void Start() 
    {
        //они спавняться,но не на месте _spawnerPoints,пыталась исправить,при каких то определенных только обостоятельствах все идет как надо
       _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemies = new List<EnemyAI>();
    }
    private void IncreadeEnemiesMaxCount()
    {
        enemiesMaxCount++;
        Invoke("IncreadeEnemiesMaxCount",IncreadeEnemiesDelay);
    }
    private void Update() 
    {
        for(var i = 0; i < _enemies.Count;i++)
        {
            if(_enemies[i].IsAlive()) continue;
            _enemies.RemoveAt(i);
            i--;
        }
        if(_enemies.Count >= enemiesMaxCount)return;
        if(Time.time - _timeLastSpawned < delay) return;

    

        CreateEnemy();
        
    }
    private void CreateEnemy()
    {
        var enemy = Instantiate(enemyAIPrefabs);
        enemy.transform.position = _spawnerPoints[Random.Range(0,_spawnerPoints.Count)].transform.position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        _enemies.Add(enemy);
        _timeLastSpawned = Time.time;
        
    }

   
}
