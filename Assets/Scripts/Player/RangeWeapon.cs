using UnityEngine;

public class RangeWeapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RangeAttack range = collision.GetComponent<RangeAttack>();

        if (range != null)
        {
            range.UnlockRangeWeapon();
            Destroy(gameObject);
        }

    }
}
