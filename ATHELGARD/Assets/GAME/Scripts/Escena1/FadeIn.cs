using System.Collections;
using UnityEngine;

public class FadeIn : MonoBehaviour
{

    private AudioSource sonido;

    public CanvasGroup canvasGroup;

    public float duracionFade = 1f;

    private bool fadeInCompletado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            if (fadeInCompletado == false)
            {
                Debug.Log("Player ha entrado en el trigger del FadeIn.");
                Mostrar();
            }
           
        }

        fadeInCompletado = true;
    }

    private void Awake()
    {
         canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(false);
        sonido = GetComponent<AudioSource>();
    }

    public void Mostrar()
    {
        canvasGroup.gameObject.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(FadeInF());
        sonido.Play();
    }

    IEnumerator FadeInF()
    {
        float tiempo = 0;

        while (tiempo < duracionFade)
        {
            tiempo += Time.deltaTime;

            canvasGroup.alpha =
                Mathf.Lerp(0, 1, tiempo / duracionFade);

            yield return null;
        }

        canvasGroup.alpha = 1;
    }
}
