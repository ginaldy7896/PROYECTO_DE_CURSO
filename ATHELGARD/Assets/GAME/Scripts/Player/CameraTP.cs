using Unity.VisualScripting;
using UnityEngine;

public class CameraTP : MonoBehaviour
{
    public float mouseSensitivity = 10f;

    public Transform target;

    private float rotY, rotX;

    public float distanceTarget = 5f;

    public float cameraRadius = 0.3f;
    public LayerMask collisionMask;

    Vector3 curRotation;
    Vector3 smoothVelocity = Vector3.zero;

    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private Vector2 MaxMinRota = new Vector2(-10, 40);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        HandlePosition();
        HandleRotation();
    }

    public void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotY += mouseX;
        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, MaxMinRota.x, MaxMinRota.y);
        Vector3 targetRotation = new Vector3(rotX, rotY);
        curRotation = Vector3.SmoothDamp(curRotation, targetRotation, ref smoothVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(curRotation);
        

    }

   

    public void HandlePosition()
    {
        Vector3 direction = -transform.forward;

        RaycastHit hit;

        if (Physics.SphereCast(
            target.position,
            cameraRadius,
            direction,
            out hit,
            distanceTarget,
            collisionMask))
        {
            transform.position =
                target.position +
                direction * hit.distance;
        }
        else
        {
            transform.position =
                target.position +
                direction * distanceTarget;
        }
    }
}
