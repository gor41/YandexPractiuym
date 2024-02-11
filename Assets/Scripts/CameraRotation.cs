using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    public Transform CameraAxisTransform;
    public float  minAngle;
    public float  maxAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0 , transform.localEulerAngles.y + (Time.deltaTime * _rotationSpeed *  Input.GetAxis("Mouse X")), 0);
        
        var newAngleX = CameraAxisTransform.localEulerAngles.x - (Time.deltaTime * _rotationSpeed *  Input.GetAxis("Mouse Y"));
        if (newAngleX>180)
        newAngleX-= 360;
        
        newAngleX = Mathf.Clamp(newAngleX,minAngle,maxAngle);
        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0 , 0);
    }

}
