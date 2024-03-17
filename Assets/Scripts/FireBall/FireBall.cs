using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float lifeTime;
    public float damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireBall",lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        MoveFareBall();
    }

    private void MoveFareBall()
    {
        {
        transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
       DestroyFireBall();
    }
    public void DestroyFireBall()
    {
        Destroy(gameObject);
    }
}
