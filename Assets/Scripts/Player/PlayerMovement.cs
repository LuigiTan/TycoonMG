using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed, runSpeed;
    public bool canMove;

    private Vector3 vectorMovement;
    private float speed;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {

        characterController = GetComponent<CharacterController>();
        speed = walkSpeed;
        vectorMovement = Vector3.zero;
    }

    
    void Update()
    {
        if (canMove)
        {
            Walk();
            Run();
        }
        Gravity();
    }
    //Funciones para caminar
    void Walk()        
    {
        //COnseguimos los inputs"
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis ("Vertical");
        //Normalizamos el vector de movimiento
        vectorMovement = vectorMovement.normalized;
        //Movemos al player
        characterController.Move(vectorMovement* speed * Time.deltaTime);

    }
    void Run()
    {
        //Si presionamos el boton para correr modificamos la velocidad
        if(Input.GetAxis("Run") > 0f)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }
    //Funcion provisional de gravedad
    void Gravity()
    {
        characterController.Move(new Vector3(0f, -4f * Time.deltaTime, 0f));
    }
}
