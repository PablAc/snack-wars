
using UnityEngine;

public class LivePotion : MonoBehaviour
{

    [SerializeField] private float _lifePotion = 5f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerHealt>(out PlayerHealt e)) 
        {
           e.Heal(_lifePotion);
           Destroy(gameObject);
        }
    }


}
