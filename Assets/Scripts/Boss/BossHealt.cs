using UnityEngine;

public class BossHealt : MonoBehaviour
{
    private Animator _animator;
    public int Bosshealt = 5;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        Bosshealt -= damage;
        if (Bosshealt <= 0)
        {
            _animator.SetTrigger("IsDead");
            GameController.instance.ActivateVictoryScreen();

        }
    }

    private void DestroyBoss()
    {
        Destroy(gameObject);
    }
}
