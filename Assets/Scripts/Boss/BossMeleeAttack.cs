using UnityEngine;

public class BossMeleeAttack : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerHealt>(out PlayerHealt e))
        {
            e.TakeDamage(_damage);

        }
        
        
    }

}
