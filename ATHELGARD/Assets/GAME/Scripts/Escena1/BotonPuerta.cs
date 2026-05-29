using UnityEngine;

public class BotonPuerta : MonoBehaviour
{
    public GameObject puerta; // Arrastra aquí la puerta
    public GameObject panel;
    public AudioClip sonido; // Arrastra aquí el sonido de la puerta
    private bool puedePresionar = false;
    private bool interactuado = false;

    void Update()
    {
        // Si el jugador está cerca y presiona E
        if (puedePresionar && Input.GetKeyDown(KeyCode.E) && !interactuado)
        {
            puerta.SetActive(false); // Desaparece la puerta
            AudioSource.PlayClipAtPoint(sonido, transform.position); // Reproduce el sonido
            interactuado=true;
        }
    }

    // Cuando el jugador entra al área
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puedePresionar = true;
            panel.SetActive(true);
        }
    }

    // Cuando sale del área
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puedePresionar = false;
            panel.SetActive(false);
        }
    }
}
