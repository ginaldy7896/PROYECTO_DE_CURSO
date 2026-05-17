using UnityEngine;

public class MovimientoQ : MonoBehaviour
{
    [Header("Velocidades")]
    public float walkSpeed = 4f;
    public float runSpeed = 8f;
    public float backwardSpeed = 2f;
    public float strafeSpeed = 3f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;

    [Header("Animator")]
    public Animator anima;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        bool running = Input.GetKey(KeyCode.LeftShift);

        Vector3 moveDirection =
        (transform.forward * moveVertical) +
        (transform.right * moveHorizontal);

        moveDirection = moveDirection.normalized;

        float finalSpeed = walkSpeed;

        if (running && moveVertical > 0)
        {
            finalSpeed = runSpeed;
        }

        if (moveVertical < 0)
        {
            finalSpeed = backwardSpeed;
        }

        Vector3 finalMovement =
            moveDirection *
            finalSpeed *
            Time.fixedDeltaTime;

        rb.MovePosition(rb.position + finalMovement);

        float animZ = 0f;
        float animX = 0f;

        if (moveVertical > 0)
        {
            animZ = 0.5f;

            if (running)
            {
                animZ = 2f;
            }
        }

        if (moveVertical < 0)
        {
            animZ = -0.5f;
        }

        if (moveHorizontal > 0)
        {
            animX = 0.5f;
        }

        if (moveHorizontal < 0)
        {
            animX = -0.5f;
        }

        anima.SetFloat("XSpeed", animX);
        anima.SetFloat("ZSpeed", animZ);
    }
}