using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    //Varibales publicas
    public float radius;
    public LayerMask dectectedLayers;
    //Variables privadas
    private bool isGrounded;

   

    // Update is called once per frame
    void Update()
    {
        CheckGround();
    }
    //Funcion para comprobar si estamos tocando el suelo
    void CheckGround () 
    {
        isGrounded = Physics.CheckSphere(transform.position, radius, dectectedLayers);
    }

    public bool GetIsGrounded()
    {
        return isGrounded; 
    }
}
