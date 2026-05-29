using UnityEngine;
using TMPro;

public class ObjetoInteractivo : MonoBehaviour
{
    [Header("UI de Interacción (Pantalla)")]
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TextMeshProUGUI textoDialogo;

    [Header("UI Flotante (Mundo 3D)")]
    [SerializeField] private GameObject canvasIconoFlotante; 

    [Header("Configuración del Diálogo")]
    [TextArea(3, 5)]
    [SerializeField] private string mensajeDeDialogo = "¡Hola viajero! Bienvenido a mi juego.";

    private bool jugadorEstaCerca = false;

    void Start()
    {
        if (panelDialogo != null) panelDialogo.SetActive(false);
        if (canvasIconoFlotante != null) canvasIconoFlotante.SetActive(false); // Empieza oculto
    }

    void Update()
    {
        if (jugadorEstaCerca && Input.GetKeyDown(KeyCode.E))
        {
            if (panelDialogo.activeSelf)
            {
                CerrarDialogo();
            }
            else
            {
                AbrirDialogo();
            }
        }

        // OPTIONAL / BONUS: Hacer que el icono mire siempre a la cámara para que no se vea plano
        if (canvasIconoFlotante != null && canvasIconoFlotante.activeSelf)
        {
            canvasIconoFlotante.transform.LookAt(canvasIconoFlotante.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        }
    }

    void AbrirDialogo()
    {
        if (panelDialogo != null && textoDialogo != null)
        {
            textoDialogo.text = mensajeDeDialogo;
            panelDialogo.SetActive(true);

            // Ocultamos el iconito flotante mientras lee para no saturar la pantalla
            if (canvasIconoFlotante != null) canvasIconoFlotante.SetActive(false);
        }
    }

    void CerrarDialogo()
    {
        if (panelDialogo != null) panelDialogo.SetActive(false);

        // Si cerramos el diálogo pero seguimos cerca, volvemos a mostrar el iconito E
        if (jugadorEstaCerca && canvasIconoFlotante != null) canvasIconoFlotante.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEstaCerca = true;

            // Si el diálogo no está abierto, mostramos el icono flotante de inmediato
            if (canvasIconoFlotante != null && !panelDialogo.activeSelf)
            {
                canvasIconoFlotante.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEstaCerca = false;
            CerrarDialogo();

            // Si se aleja, nos aseguramos de apagar el icono flotante
            if (canvasIconoFlotante != null) canvasIconoFlotante.SetActive(false);
        }
    }
}