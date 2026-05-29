using UnityEngine;

public class AnimarLava : MonoBehaviour
{
    [Header("Velocidad de flujo")]
    public float velocidadX = 0.05f;
    public float velocidadY = 0.02f;

    private Material materialLava;
    private Vector2 offsetActual;

    void Start()
    {
        
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            materialLava = renderer.material;
        }
    }

    void Update()
    {
        if (materialLava != null)
        {
           
            offsetActual.x += velocidadX * Time.deltaTime;
            offsetActual.y += velocidadY * Time.deltaTime;

            
            materialLava.SetTextureOffset("_MainTex", offsetActual);
            materialLava.SetTextureOffset("_BumpMap", offsetActual);  // Mueve el relieve físico
            materialLava.SetTextureOffset("_EmissionMap", offsetActual); // Mueve el brillo rojo
        }
    }
}