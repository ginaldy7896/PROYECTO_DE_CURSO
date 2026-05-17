using System;
using UnityEngine;

public class MovoJugadorTCP : MonoBehaviour
{
    private CharacterController controller;

    [Header("Movimiento")]
    public float veloRota = 10f;
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
   

    [Header("Suelo")]
    public LayerMask piso;
    public Transform checkPiso;
    public float distanciaPiso = 0.4f;

    [Header("Salto")]
    private float gravedad = -9.81f;
    public float salto = 1.5f;

    [Header("Camara")]
    public Camera followCamera;

    [Header("Animator")]
    public Animator anima;

    private bool enPiso;

    private Vector3 veloJugador;

    private float X;
    private float Z;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        enPiso = Physics.CheckSphere(
            checkPiso.position,
            distanciaPiso,
            piso
        );

        if (enPiso && veloJugador.y < 0)
        {
            veloJugador.y = -2f;
        }

        X = Input.GetAxisRaw("Horizontal");
        Z = Input.GetAxisRaw("Vertical");

        bool running = Input.GetKey(KeyCode.LeftShift);

        float currentSpeed = walkSpeed;

        if (running)
        {
            currentSpeed = runSpeed;
        }
        

        Vector3 moveInput =
            Quaternion.Euler(
                0,
                followCamera.transform.eulerAngles.y,
                0
            ) * new Vector3(X, 0, Z);

        Vector3 moveDirection = moveInput.normalized;

        controller.Move(
            moveDirection *
            currentSpeed *
            Time.deltaTime
        );

        Vector3 forwardCamera = followCamera.transform.forward;

        if (Z != 0)
        {
            Vector3 lookDirection = forwardCamera;

            if (Z < 0)
            {
                lookDirection = -forwardCamera;
            }

            Quaternion rotacion =
                Quaternion.LookRotation(
                    moveDirection,
                    Vector3.up
                );

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rotacion,
                veloRota * Time.deltaTime
            );
        }


        if (Input.GetButtonDown("Jump") && enPiso)
        {
            veloJugador.y =
                Mathf.Sqrt(salto * -2f * gravedad);
        }

        veloJugador.y += gravedad * Time.deltaTime;

        controller.Move(veloJugador * Time.deltaTime);

        float animX = 0f;
        float animZ = 0f;

        if (Z != 0)
        {
            animZ = 0.5f;

            if (running)
            {
                animZ = 2f;
            }
        }

        

        if (X > 0)
        {
            animX = 0.5f;
        }

        if (X < 0)
        {
            animX = -0.5f;
        }

        float dot =
        Vector3.Dot(
        transform.forward,
        forwardCamera
    );

        if (dot < 0)
        {
            animX *= -1;
        }

        anima.SetFloat("XSpeed", animX, 0.1f, Time.deltaTime);
        anima.SetFloat("ZSpeed", animZ, 0.1f, Time.deltaTime);
    }
}