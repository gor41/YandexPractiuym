using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    public float damage = 50;
    public GameObject ExplosionPrefab;
    private void OnCollisionEnter(Collision other) 
    {
        Invoke("Explosion",delay);
    }
    private void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(ExplosionPrefab);
        explosion.transform.position = transform.position;
        explosion.GetComponent<Explosion>().damage =damage;

    }
}
