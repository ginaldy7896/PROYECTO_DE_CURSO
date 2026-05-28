using UnityEngine;

public class LavaMortal : MonoBehaviour
{
    private bool murio = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !murio)
        {
            murio = true;

            CheckpointManager cp =
            FindFirstObjectByType<CheckpointManager>();

            if (cp != null)
            {
                cp.Regresar();
            }

            murio = false;
        }
    }
}