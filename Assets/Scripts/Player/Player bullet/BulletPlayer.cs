using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemiHealt>(out EnemiHealt e))
        {
            e.TakeDamage(_damage);

            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag ("Levelcolider"))
        {
            Destroy(gameObject);
        }
    }


}
