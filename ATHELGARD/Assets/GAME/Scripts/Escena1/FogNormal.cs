using UnityEngine;

public class FogNormal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RenderSettings.fog = true;

            // Densidad normal
            RenderSettings.fogDensity = 0.01f;

            // Color hexadecimal #DDA04A
            Color colorNaranja;

            ColorUtility.TryParseHtmlString("#DDA04A", out colorNaranja);

            RenderSettings.fogColor = colorNaranja;
        }
    }
}
