using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SceneManagement;

public class PlayerHealt : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;

    [SerializeField] public float Health = 5;
    [SerializeField] public float MaxHealth = 5;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        Health = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health >0)

        {
            PlayerHurt();
            
        }
        else
        {
            PlayerDead();
        }
    }
    private void PlayerHurt()
    {
        _animator.SetTrigger("IsHurt");

    }

    private void PlayerDead()
    {
        _animator.SetTrigger("IsDead");

       
    }

    private void SceneReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttack"))
        {
            TakeDamage(1);
        }
    }
}
