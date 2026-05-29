using UnityEngine;

public class VorticePortal : MonoBehaviour
{
    [Header("Velocidad de la Espiral")]
    public float velocidadGiro = 2f;
    public float velocidadSuccion = 0.5f;

    private Material materialPortal;
    private float tiempo = 0f;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            materialPortal = rend.material;
        }
    }

    void Update()
    {
        if (materialPortal != null)
        {
            tiempo += Time.deltaTime;

            
            float offsetX = Mathf.Cos(tiempo * velocidadGiro) * velocidadSuccion;
            float offsetY = Mathf.Sin(tiempo * velocidadGiro) * velocidadSuccion;

            Vector2 offsetFinal = new Vector2(offsetX, offsetY);
       
            materialPortal.SetTextureOffset("_MainTex", offsetFinal);
            materialPortal.SetTextureOffset("_BumpMap", offsetFinal);
        }
    }
}