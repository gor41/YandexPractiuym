using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCast : MonoBehaviour
{
    public FireBall fireBallPrefab;
    public Transform fireballSourceTransform;

    public float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FireBallAttack();
    }
    private void FireBallAttack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(fireBallPrefab,fireballSourceTransform.position,fireballSourceTransform.rotation);

            fireball.damage = damage;
        }

    }
}
