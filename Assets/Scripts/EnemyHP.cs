using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] GameObject mainBody;
    [SerializeField]float maxHP;
    [SerializeField] float currentHP;
    [SerializeField] GameObject HPcake;

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
                //Destroy(collision.gameObject);
                if(Random.Range(0f,1f) < 0.6f)
                {
                    Instantiate(HPcake, this.transform.position, Quaternion.identity, null);
                }
                Destroy(mainBody);
            }
        }
    }
}
