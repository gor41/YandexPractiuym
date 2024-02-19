using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public float lifeTime;
    public float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
    var enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
    if(value != 0)
    {
        DealDamage();
    }
    
    }  
    public void DealDamage()
    {
        value -= damage;
        if(value <= 0)
        {
            Destroy(gameObject);
        }
    } 
}
