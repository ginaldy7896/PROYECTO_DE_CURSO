using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalVideo : MonoBehaviour
{
    public GameObject puertaFinal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;

            puertaFinal.SetActive(true);

            Cursor.lockState =
                CursorLockMode.None;

            Cursor.visible = true;
        }
    }

    public void siguienteEscena()
    {
        SceneManager.LoadScene("SceneMenu");
    }
}
