using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SceneManagement;

public class PlayerHealt : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;

    [SerializeField] public float Health = 5f;
    [SerializeField] public float MaxHealth = 5f;
    [SerializeField] AudioClip damageClip;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        Health = MaxHealth;
    }

    public void Heal(float cure) 
    {
        if (Health < 5f)
        {
            Health += cure;
            if (Health > 5f) Health = 5f;
        }

    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health >0)

        {
            SFXmanager.instance.PlaySFX(damageClip, this.transform, UnityEngine.Random.Range(1f, 1.5f));
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
