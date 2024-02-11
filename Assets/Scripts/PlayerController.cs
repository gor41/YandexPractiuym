using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     private float _fallVelocity = 0f;
     private float gravity = 9.8f;
     private CharacterController _characterController;
     public float jumpForce ;
     public float speed;
     private Vector3 _moveVector;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update() {
       
        if(Input.GetKeyDown(KeyCode.Q) && _characterController.isGrounded)
        {
        _fallVelocity = -jumpForce;
        }
        _moveVector = Vector3.zero;
    
        if(Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if(Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if(Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if(Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }

    }
}
