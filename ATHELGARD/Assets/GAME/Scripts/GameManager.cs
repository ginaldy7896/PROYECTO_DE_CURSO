using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    public GameObject panelInformacion;

    public void EmpezarJuego()
    {
       
        SceneManager.LoadScene(1);
    }

    public void AbrirInformacion()
    {
        panelInformacion.SetActive(true);
    }

    public void CerrarInformacion()
    {
        panelInformacion.SetActive(false);
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    
    public void RegresarAlMenuPrincipal()
    {
        
        SceneManager.LoadScene(0);
    }
}