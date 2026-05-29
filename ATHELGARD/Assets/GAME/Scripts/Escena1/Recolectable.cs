using UnityEngine;

public class Recolectable : MonoBehaviour
{
   private RecolectableManager manager;

    private bool recolectado = false;

    [Header("Sonido")]
    public AudioClip sonidoRecolectar;
    [Header("Narrador")]
    public AudioSource narrador;



    private void Awake()
    {
        manager =
            FindFirstObjectByType<RecolectableManager>();

        manager.RegistrarObjeto(this);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (recolectado)
            return;

        if (other.CompareTag("Player"))
        {
            recolectado = true;

            manager.RegistrarRecolectable();

            AudioSource.PlayClipAtPoint(
                sonidoRecolectar,
                transform.position
            );

            gameObject.SetActive(false);
        }
    }
}
