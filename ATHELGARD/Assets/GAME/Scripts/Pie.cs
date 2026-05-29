using UnityEngine;

public class Pie : MonoBehaviour
{
    public AudioSource paso;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Suelo"))
        {
            paso.Play();
        }
    }
}
