using UnityEngine;

public class Water : MonoBehaviour
{
    public Transform respawnWater;
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
               GameManager.Instance.PerderVida();

            CharacterController cc = other.GetComponent<CharacterController>();

            cc.enabled = false;
            other.transform.position = respawnWater.position;
            cc.enabled = true;
        }
    }
}
