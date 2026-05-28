using UnityEngine;

public class Cristal : MonoBehaviour
{
    [Header("Flotación")]
    public float altura = 0.5f;
    public float velocidadFlotar = 2f;

    [Header("Rotación")]
    public float velocidadRotacion = 60f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Flota arriba y abajo
        transform.position =
            posicionInicial +
            Vector3.up *
            Mathf.Sin(
                Time.time *
                velocidadFlotar
            ) * altura;

        // Gira
        transform.Rotate(
            0,
            velocidadRotacion *
            Time.deltaTime,
            0
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<FireCollector>()
            .Recoger(gameObject);

            Destroy(gameObject);
        }
    }
}