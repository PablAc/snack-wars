using UnityEngine;

public class BossAreaAttacks : MonoBehaviour
{
    
    public BossMovement _boss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _boss._playerInMeleeRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _boss._playerInMeleeRange = false;
            
        }
    }
}


