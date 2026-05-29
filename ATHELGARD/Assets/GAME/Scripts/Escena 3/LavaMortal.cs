using UnityEngine;

public class LavaMortal : MonoBehaviour
{
    private bool murio = false;

    private void OnTriggerEnter(Collider other)
    {
        MovoJugadorTCP jugador = other.GetComponentInParent<MovoJugadorTCP>();

        if (jugador != null && !murio)
        {
            murio = true;

            
            CharacterController controller = jugador.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
            }

            
            System.Reflection.FieldInfo infoVelo = typeof(MovoJugadorTCP).GetField("veloJugador", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (infoVelo != null)
            {
                infoVelo.SetValue(jugador, Vector3.zero);
            }

            
            CheckpointManager cp = FindFirstObjectByType<CheckpointManager>();
            if (cp != null)
            {
                cp.Regresar();
            }

            
            if (controller != null)
            {
                controller.enabled = true;
            }

            murio = false;

            GameManager.Instance.PerderVida();
        }
    }
}