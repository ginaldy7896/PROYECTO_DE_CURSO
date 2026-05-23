using System.Collections;
using TMPro;
using UnityEngine;

public class Scene1Manager : MonoBehaviour
{
    [Header("UI Elementos")]
    [SerializeField] private CanvasGroup contenedorCartelUI;
    public TextMeshProUGUI textoCartel;

    [Header("Configuración del Desvanecimiento")]
    public float tiempoEsperaAntesDelFade = 1.5f;
    public float duracionDelFade = 1.0f;

    private bool instruccionesCompletadas = false;

    void Start()
    {
        if (contenedorCartelUI != null)
        {
            contenedorCartelUI.gameObject.SetActive(true);
            textoCartel.text = "Usa el teclado para controlar tu posición en el entorno. Presiona todas las direcciones para comenzar la simulación:\r\nW • A • S • D";
            contenedorCartelUI.alpha = 1f;
        }
    }

    void Update()
    {
        bool presionoSalto = Input.GetButtonDown("Jump");
        // Si ya detectamos el movimiento una vez, ignoramos el resto del Update
        if (instruccionesCompletadas) { 
        
            textoCartel.text = "Preciona espacio para saltar, y el mouse para mirar alrededor. ¡Explora el entorno!";

            if (presionoSalto)
            {
                StartCoroutine(SecuenciaDesvanecerCartel());
            }
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // En cuanto haya cualquier intento de movimiento (Horizontal o Vertical)
        if (h != 0 || v != 0)
        {
            instruccionesCompletadas = true;


        }
    }

   

    IEnumerator SecuenciaDesvanecerCartel()
    {
        if (contenedorCartelUI != null)
        {
            // Espera el tiempo de gracia antes de empezar a borrarse
            yield return new WaitForSeconds(tiempoEsperaAntesDelFade);

            float tiempoPasado = 0f;
            while (tiempoPasado < duracionDelFade)
            {
                tiempoPasado += Time.deltaTime;

                // Reduce la opacidad gradualmente de forma fluida
                contenedorCartelUI.alpha = Mathf.Lerp(1f, 0f, tiempoPasado / duracionDelFade);
                yield return null;
            }

            
            contenedorCartelUI.gameObject.SetActive(false);
        }
    }
}