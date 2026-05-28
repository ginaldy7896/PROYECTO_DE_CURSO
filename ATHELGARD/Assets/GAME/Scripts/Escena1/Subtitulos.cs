using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Subtitulo
{
    [TextArea]
    public string texto;

    public float tiempoInicio;

    public float duracion;
}

public class Subtitulos : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;

    [Header("UI")]
    public TextMeshProUGUI textoSubtitulo;

    [Header("Lista de subtítulos")]
    public List<Subtitulo> subtitulos =
        new List<Subtitulo>();

    private void Start()
    {
        textoSubtitulo.text = "";
    }

    public void IniciarNarracion()
    {
        audioSource.Play();

        StartCoroutine(
            MostrarSubtitulos()
        );
    }

    IEnumerator MostrarSubtitulos()
    {
        foreach (Subtitulo s in subtitulos)
        {
            yield return new WaitForSeconds(
                s.tiempoInicio -
                audioSource.time
            );

            textoSubtitulo.text = s.texto;

            yield return new WaitForSeconds(
                s.duracion
            );

            textoSubtitulo.text = "";
        }
    }
}
