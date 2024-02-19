using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCast : MonoBehaviour
{
    public FireBall fireBallPrefab;
    public Transform fireballSourceTransform;
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
            Instantiate(fireBallPrefab,fireballSourceTransform.position,fireballSourceTransform.rotation);
        }

    }
}
