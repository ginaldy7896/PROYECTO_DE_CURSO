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

            // 1. Apagamos el CharacterController para poder moverlo
            CharacterController controller = jugador.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
            }

            // 2. EL TRUCO: Accedemos por código a la variable de tus compañeros y la reseteamos a cero
            // Esto evita que el personaje conserve la velocidad de caída infinita
            System.Reflection.FieldInfo infoVelo = typeof(MovoJugadorTCP).GetField("veloJugador", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (infoVelo != null)
            {
                infoVelo.SetValue(jugador, Vector3.zero);
            }

            // 3. Tu lógica de regreso normal
            CheckpointManager cp = FindFirstObjectByType<CheckpointManager>();
            if (cp != null)
            {
                cp.Regresar();
            }

            // 4. Lo volvemos a prender limpio y sin velocidad acumulada
            if (controller != null)
            {
                controller.enabled = true;
            }

            murio = false;
        }
    }
}