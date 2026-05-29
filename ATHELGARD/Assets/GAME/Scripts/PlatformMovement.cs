using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float platformSpeed = 2f;

    private int waypointIndex = 0;

    private Vector3 lastPosition;

    private CharacterController player;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        MovePlatform();

        MovePlayerWithPlatform();

        lastPosition = transform.position;
    }

    void MovePlatform()
    {
        Transform target = waypoints[waypointIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            platformSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            waypointIndex++;

            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
    }

    void MovePlayerWithPlatform()
    {
        if (player != null)
        {
            Vector3 platformMovement = transform.position - lastPosition;

            player.Move(platformMovement);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Encotnrado el player");
            player = other.GetComponent<CharacterController>();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }
}
