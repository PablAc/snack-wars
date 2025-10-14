using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float lifeTime;
    float timeLeft;

    private void Awake()
    {
        timeLeft = lifeTime;
    }
    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime; 
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
