using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private HealthManager healthManager;

    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bird"))
        {
            healthManager.TakeDamage();
        }
    }
}
