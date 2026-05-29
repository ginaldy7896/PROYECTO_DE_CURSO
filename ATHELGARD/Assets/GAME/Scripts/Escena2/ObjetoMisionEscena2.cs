using UnityEngine;

public class ObjetoMisionEscena2 : MonoBehaviour
{
    [Header("Efectos")]
    public float velocidadRotacion = 100f;

    void Update()
    {
        // Hace que el objeto gire de forma bonita en el mapa para que llame la atención
        transform.Rotate(0, velocidadRotacion * Time.deltaTime, 0);
    }

    // Se activa cuando el jugador pasa flotando o corriendo a través del objeto
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Accedemos al Scene2Manager único de tu escena para sumar el fragmento
            if (Scene2Manager.instance != null)
            {
                Scene2Manager.instance.RecogerFragmento();
            }

            // Destruimos el objeto del mapa porque ya fue recolectado
            Destroy(gameObject);
        }
    }
}
