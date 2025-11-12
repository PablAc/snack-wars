using UnityEngine;

public class EnemyPatroller : MonoBehaviour
{
    protected GameObject PlayerObj;
    [SerializeField] protected float enemySpeed;
    protected bool isPlayerInRange;
    [SerializeField]protected float shootTimerSet;
    [SerializeField]protected GameObject bulletPrefab;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected AudioClip shootClip;
    [SerializeField] bool canMove = true;
    protected float shootTimer;

    private void Awake()
    {
        PlayerObj = GameController.instance.PlayerObj;
        isPlayerInRange = false;
        shootTimer = shootTimerSet;
    }
    private void Update()
    {
        if (!isPlayerInRange && canMove)
        {
            shootTimer = shootTimerSet;
            transform.position = Vector2.MoveTowards(this.transform.position, PlayerObj.transform.position, enemySpeed * Time.deltaTime);
        }
        else if(shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        else
        {
            Shoot();
            shootTimer = shootTimerSet;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
    void Shoot()
    {
        Vector2 direction = (PlayerObj.transform.position - this.transform.position).normalized;
        GameObject firingBullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        SFXmanager.instance.PlaySFX(shootClip, this.transform, UnityEngine.Random.Range(0.5f, 0.9f));
        Rigidbody2D bulletRB = firingBullet.GetComponent<Rigidbody2D>();
        bulletRB.linearVelocity = direction * bulletSpeed;
    }
}
