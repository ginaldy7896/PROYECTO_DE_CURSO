using UnityEngine;
using UnityEngine.AI;

public class Enemigo2 : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    //private Vector3 start;

    public float rangoDeteccion = 10f;
    public float rangoAtaque = 2f;
    public Transform[] waypoints;
    public float waypointsDistance = 1f;
    private int currentWaypoint = 0;
    private Animator ani;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        //start = transform.position;

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.position);

        // ATACAR
        if (distancia <= rangoAtaque)
        {
            // Detener completamente el agente
            agent.isStopped = true;

            // Mirar al jugador
            Vector3 direccion = (player.position - transform.position).normalized;
            direccion.y = 0;

            if (direccion != Vector3.zero)
            {
                Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);

                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    rotacionObjetivo,
                    Time.deltaTime * 5f
                );
            }

            // Animaciones
            ani.SetBool("atack", true);
            ani.SetBool("run", false);
            ani.SetBool("caminar", false);
        }

        // PERSEGUIR
        else if (distancia <= rangoDeteccion)
        {
            agent.isStopped = false;

            agent.SetDestination(player.position);

            ani.SetBool("run", true);
            ani.SetBool("caminar", false);
            ani.SetBool("atack", false);
        }

        // PATRULLAR
        else

        {
            agent.isStopped = false;
            ani.SetBool("caminar", true);
            ani.SetBool("run", false);
            ani.SetBool("atack", false);

            if (!agent.pathPending && agent.remainingDistance < waypointsDistance)
            {
                GoToNextWaypoint();
            }
        }
    }

    public void GoToNextWaypoint()
    {
        currentWaypoint++;

        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }

        agent.SetDestination(waypoints[currentWaypoint].position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }

    public void Final_Ani()
    {
        ani.SetBool("atack", false);
        
    }
}
