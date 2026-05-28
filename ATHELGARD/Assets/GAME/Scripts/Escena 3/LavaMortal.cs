using UnityEngine;

public class LavaMortal : MonoBehaviour
{
    private bool murio = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !murio)
        {
            murio = true;

            // 1. Buscamos el CharacterController en el personaje que cayó a la lava
            CharacterController controller = other.GetComponent<CharacterController>();

            // 2. Si el personaje usa CharacterController, lo apagamos para que no se bugee
            if (controller != null)
            {
                controller.enabled = false;
            }

            // 3. Tu lógica original: Buscamos el mánager y lo regresamos al checkpoint
            CheckpointManager cp = FindFirstObjectByType<CheckpointManager>();
            if (cp != null)
            {
                cp.Regresar();
            }

            // 4. Lo volvemos a encender inmediatamente para que pueda seguir caminando
            if (controller != null)
            {
                controller.enabled = true;
            }

            murio = false;
        }
    }
}