using UnityEngine;

public class BossRangeAttack : MonoBehaviour
{
    public GameObject BossBullet;
    public Transform bulletTransform;
    [SerializeField] private float _bulletSpeed = 10f;

    public void RangeAttack()
    {
        Vector2 dir = Vector2.down;

        GameObject bullet = Instantiate(BossBullet, bulletTransform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.gameObject.GetComponent<Rigidbody2D>();
        rb.linearVelocity = dir * _bulletSpeed;
        bullet.transform.right = dir;

    }
}
