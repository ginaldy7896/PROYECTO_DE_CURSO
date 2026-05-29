using TMPro;
using UnityEngine;

public class TimerJuego : MonoBehaviour
{
    [Header("Tiempo")]
    public float tiempoInicial = 120f; // 2 minutos

    [Header("UI")]
    public TextMeshProUGUI textoTiempo;

    private float tiempoActual;
    private bool tiempoTerminado = false;

    void Start()
    {
        tiempoActual = tiempoInicial;
    }

    void Update()
    {
        if (tiempoTerminado)
            return;

        tiempoActual -= Time.deltaTime;

        if (tiempoActual <= 0)
        {
            tiempoActual = 0;
            FinDelTiempo();
        }

        MostrarTiempo();
    }

    void MostrarTiempo()
    {
        int minutos = Mathf.FloorToInt(tiempoActual / 60);
        int segundos = Mathf.FloorToInt(tiempoActual % 60);

        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    void FinDelTiempo()
    {
        tiempoTerminado = true;

        // Quitar las 4 vidas
        GameManager.Instance.vidasActuales = 0;

        // Ejecutar derrota
        GameManager.Instance.ActivarGameOver();
    }
}
