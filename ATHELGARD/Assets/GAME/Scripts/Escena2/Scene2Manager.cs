using System.Collections;
using TMPro;
using UnityEngine;

public class Scene2Manager : MonoBehaviour
{
    public static Scene2Manager instance;

    [Header("UI Elementos")]

    public TextMeshProUGUI textoMision;

    [Header("Mision")]
    public int fragmentosNecesarios = 5;
    private int fragmentosActuales = 0;


    //private bool instruccionesCompletadas = false;
    public GameObject puertaFinal;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ActualizarUI();
    }



    void Update()
    {

    }

    public void RecogerFragmento()
    {
        fragmentosActuales++;

        ActualizarUI();

        if (fragmentosActuales >= fragmentosNecesarios)
        {
            CompletarMision();
        }
    }

    void ActualizarUI()
    {
        textoMision.text =
            "Fragmentos: " +
            fragmentosActuales +
            "/" +
            fragmentosNecesarios;
    }

    void CompletarMision()
    {
        textoMision.text = "Misión completada";

        Debug.Log("MISIÓN COMPLETADA");
        puertaFinal.SetActive(true);
        // Aquí puedes:
        // abrir puerta
        // activar cinemática
        // cargar otra escena
        // activar enemigo final
    }




}