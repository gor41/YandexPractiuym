using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFareBall",lifeTime);
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
       DestroyFareBall();
    }
    public void DestroyFareBall()
    {
        Destroy(gameObject);
    }
}
