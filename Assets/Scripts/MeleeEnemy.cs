using System.Collections;
using UnityEngine;

public class MeleeEnemy : EnemyPatroller
{
    private void Update()
    {
        if (!isPlayerInRange)
        {
            shootTimer = shootTimerSet;
            transform.position = Vector2.MoveTowards(this.transform.position, PlayerObj.transform.position, enemySpeed * Time.deltaTime);
        }
        else if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        else
        {
            Shoot();
            shootTimer = shootTimerSet;
        }
    }
    void Shoot()
    {
        StartCoroutine(Attack(SetAttackAngle()));
    }
    float SetAttackAngle()
    {
        Vector2 direction = (PlayerObj.transform.position - this.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        float snapped = Mathf.Round(angle / 90f) * 90f;
        return snapped;
    }
    IEnumerator Attack(float angle)
    {
        bulletPrefab.SetActive(true);
        bulletPrefab.transform.rotation = Quaternion.Euler(0, 0, angle);
        yield return new WaitForSeconds(bulletSpeed);
        bulletPrefab.SetActive(false);
    }
}
