using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class AptechkaSpawner : MonoBehaviour
{
    public Aidkit AptechkaPrefab;
    private Aidkit _aidkit;
    public float delayMin = 3;
    public float delayMax = 9;
    private List<Transform> _spawnerPoints;


    private void Start() 
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        
    }

    private void Update() 
    {
        if(_aidkit != null) return;
        if(IsInvoking()) return;
        Invoke("Spawn",Random.Range(delayMin,delayMax));        
    }



    private void Spawn()
    {
        _aidkit =  Instantiate(AptechkaPrefab);
        _aidkit.transform.position = _spawnerPoints[Random.Range(0,_spawnerPoints.Count)].position;
    }










}
