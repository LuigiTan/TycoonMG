using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables Publicas
    public Transform cameraAim;
    public float walkSpeed, runSpeed, jumpForce, rotationSpeed;
    public bool canMove;
    public GroundDetector groundDetector;

    //Variables privadas
    private Vector3 vectorMovement, verticalForce;
    private float speed, currentSpeed;
    private bool isGrounded;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {

        characterController = GetComponent<CharacterController>();
        speed = 0f;
        currentSpeed = 0f;  
        verticalForce = Vector3.zero;
        vectorMovement = Vector3.zero;
    }

    
    void Update()
    {
        //Si nos podemos mover
        if (canMove)
        {
            Walk();
            Run();
            AlignPlayer();
            Jump();
        }
        Gravity();
        CheckGround();
    }
    //Funciones para caminar
    void Walk()        
    {
        //COnseguimos los inputs"
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis ("Vertical");
        //Normalizamos el vector de movimiento
        vectorMovement = vectorMovement.normalized;

        //Nos movemos en direccion a la camara
        vectorMovement = cameraAim.TransformDirection(vectorMovement);

        //Guardamos la velocidad actual con suavizado
        currentSpeed = Mathf.Lerp(currentSpeed, vectorMovement.magnitude * speed, 10f * Time.deltaTime);

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

    //Funcion para saltar
    void Jump()
    {
        //Si estamos tocando el suelo y apretamos espacio
        if(isGrounded && Input.GetAxis("Jump") > 0f)
        {
            verticalForce = new Vector3(0f, jumpForce, 0f);
            isGrounded = false;
        }
    }
    //Funcion provisional de gravedad
    void Gravity()
    {
        //Si no estamos tocando el suelo
        if (!isGrounded)  
        {
            verticalForce += Physics.gravity * Time.deltaTime;       
        }
        else
        {
            verticalForce = new Vector3 (0f, -2f, 0f);
        }

        //Aplicar la fuerza vertical
        characterController.Move(verticalForce * Time.deltaTime);
    }

    //Funcion para linear al jugador hacia donde se mueve
    void AlignPlayer()
    {
        //Si nos estamos moviendo, alineamos la rotacion
        if(characterController.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vectorMovement), rotationSpeed * Time.deltaTime);
        }
    }
    //Funcion para conseguir el valor de isGrounded del detector
    void CheckGround()
    {
        isGrounded =groundDetector.GetIsGrounded();
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
