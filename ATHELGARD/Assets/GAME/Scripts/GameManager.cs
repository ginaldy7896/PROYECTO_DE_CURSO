using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{

    [Header("Vidas")]
    public int vidasMaximas = 4;
    public int vidasActuales;

    [Header("UI Corazones")]
    public Image[] corazones;

    [Header("Efecto Daño")]
    public Image damagePanel;

    [Header("Game Over")]
    public GameObject panelGameOver;

    private bool gameOver = false;

    public static GameManager Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
       
    }

    void Start()
    {
        vidasActuales = vidasMaximas;
        ActualizarCorazones();

        panelGameOver.SetActive(false);

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // =========================

    public void PerderVida()
    {
        if (gameOver)
            return;

        vidasActuales--;

        if (vidasActuales < 0)
            vidasActuales = 0;

        ActualizarCorazones();

        StartCoroutine(EfectoDanio());

        if (vidasActuales <= 0)
        {
            ActivarGameOver();
        }
    }

    // =========================

    void ActualizarCorazones()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].enabled = i < vidasActuales;
        }
    }

    // =========================

    IEnumerator EfectoDanio()
    {
        Color color = damagePanel.color;

        color.a = 0.4f;
        damagePanel.color = color;

        yield return new WaitForSeconds(0.15f);

        color.a = 0f;
        damagePanel.color = color;
    }

    // =========================

    void ActivarGameOver()
    {
        Time.timeScale = 0f;

        panelGameOver.SetActive(true);

        Cursor.lockState =
            CursorLockMode.None;

        Cursor.visible = true;
    }

    // =========================

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;

        Cursor.lockState =
            CursorLockMode.Locked;

        Cursor.visible = false;

        SceneManager.LoadScene(
            SceneManager
            .GetActiveScene()
            .buildIndex);
    }
}