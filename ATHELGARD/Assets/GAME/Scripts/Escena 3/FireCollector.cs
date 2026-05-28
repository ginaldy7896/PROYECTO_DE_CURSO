using System.Collections.Generic;
using UnityEngine;

public class FireCollector : MonoBehaviour
{
    public List<GameObject> fuegos =
    new List<GameObject>();

    public int necesarios = 5;

    public GameObject portalFinal;

    public void Recoger(
        GameObject fuego)
    {
        fuegos.Add(fuego);

        Debug.Log(
        "Recolectados: "
        + fuegos.Count);

        if (
        fuegos.Count >= necesarios)
        {
            portalFinal.SetActive(
            true);

            Debug.Log(
            "Portal activado");
        }
    }
}