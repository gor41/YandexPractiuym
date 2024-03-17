using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float maxSize = 5;
    public float speedSize = 1;
    public float damage = 50;
    
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speedSize;
        if(transform.localScale.x > maxSize)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        var playerhealth = other.GetComponent<PlayerHealth>();
        if(playerhealth != null)
        {
            playerhealth.DealDamage(damage);
        

        }
        var enemyhealth = other.GetComponent<EnemyHealth>();
        if(enemyhealth != null)
        {
            enemyhealth.DealDamageEnemy(damage);
            
        }
    }
}
