using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0 , transform.localEulerAngles.y + (Time.deltaTime * _rotationSpeed *  Input.GetAxis("Mouse X")), 0);
    }

}
