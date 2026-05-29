using System.Collections.Generic;
using UnityEngine;

public class RecolectableManager : MonoBehaviour
{
    [Header("Objetos recolectables")]
    public List<Recolectable> recolectables =
         new List<Recolectable>();

    private static RecolectableManager instancia;
    private int recolectados = 0;
    public GameObject puerta;

    [Header("Narrador")]
    public Subtitulos narrador;

    private bool primerRecolectable = false;

    private void Awake()
    {
        instancia = this;
    }

    public void RegistrarRecolectable()
    {
        recolectados++;

        if (!primerRecolectable)
        {
            primerRecolectable=true;
           narrador.IniciarNarracion();
        }

        Debug.Log(
            recolectados +
            "/" +
            recolectables.Count
        );

        if (TodosRecolectados())
        {
            Debug.Log("TODOS RECOLECTADOS");
            puerta.SetActive(false);
        }
    }

    public void RegistrarObjeto(Recolectable objeto)
    {
        if (!recolectables.Contains(objeto))
        {
            recolectables.Add(objeto);

            Debug.Log(
                "Objeto agregado: " +
                objeto.name
            );
        }
    }
    public bool TodosRecolectados()
    {
        return recolectados >= recolectables.Count;
    }
}
