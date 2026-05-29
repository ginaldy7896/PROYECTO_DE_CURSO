using UnityEngine;

public class Fragmento : MonoBehaviour
{

    [Header("Audio")]
    public AudioClip sonidoRecoger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(
               sonidoRecoger,
               transform.position
           );

            Scene1Manager.instance.RecogerFragmento();

            Destroy(gameObject);
        }
    }
}
