using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Variables Publicas
    public float sensibility;
    public Transform cameraJointY, targetObject;
    public bool canRotate;

    //Variables Privadas
    private float xRotation, yRotation;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializacion de variables
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Si podemos rotar
        if(canRotate)
        {
            Rotate();
        }
        //Seguimos al objetivo
        FollowTarget();
    }
    //funcion de rotacion de camara
    void Rotate()
    {
        //Conseguimos los inputs del mouse
        xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensibility;
        yRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * sensibility;

        //Ponemos limitacion al eje Y
        yRotation = Mathf.Clamp(yRotation, -65, 65);

        //Rotamos los componentes X y Y
        transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        cameraJointY.transform.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);

    }

    void FollowTarget()
    {
        transform.position = targetObject.position;
    }
}
