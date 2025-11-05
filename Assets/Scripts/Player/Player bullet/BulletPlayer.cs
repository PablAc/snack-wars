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
        if (other.TryGetComponent<BossHealt>(out BossHealt f))
        {
            f.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }


}
