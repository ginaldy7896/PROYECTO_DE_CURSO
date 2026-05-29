using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject panelFinal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState =
                CursorLockMode.None;

            Cursor.visible = true;

            panelFinal.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}