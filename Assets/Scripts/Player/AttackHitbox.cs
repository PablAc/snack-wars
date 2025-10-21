using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemiHealt>(out EnemiHealt e))
        {
            e.TakeDamage(_damage);
        }
    }
}
