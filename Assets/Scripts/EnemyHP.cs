using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] GameObject mainBody;
    [SerializeField]float maxHP;
    [SerializeField] float currentHP;

    private void Awake()
    {
        currentHP = maxHP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            currentHP--;
            if (currentHP <= 0)
            {
                Destroy(mainBody);
            }
        }
    }
}
