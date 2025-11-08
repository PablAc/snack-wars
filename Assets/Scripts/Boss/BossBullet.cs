using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _lifeTime = 5f;
    private float TimeLeft;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerHealt>(out PlayerHealt e))
        {
            e.TakeDamage(_damage);

            Destroy(gameObject);
        }
        
    }

    private void Awake()
    {
        TimeLeft = _lifeTime;
    }

    private void Update()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
