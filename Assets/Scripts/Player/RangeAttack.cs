using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangeAttack : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform bulletTransform;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _bulletCooldown = 0.4f;
    [SerializeField] private AudioClip _attackClip;


    private PlayerMovement _playerMovement;
    private Animator _animator;
    private float _lastAttackTime;



    private void Start()
    {
        _playerMovement= GetComponent<PlayerMovement>();
        _animator= GetComponent<Animator>();

    }

    private void OnRange(InputValue inputValue)
    {
        if(inputValue.Get<float>()> 0f)
        {
            TryRange();
        }
    }

    private void TryRange() 
    {
        if (Time.time < _lastAttackTime + _bulletCooldown) return;
        _lastAttackTime = Time.time;


        Vector2 dir = _playerMovement != null ?
                      _playerMovement.GetLastMoveDir() : Vector2.down;


       GameObject bullet = Instantiate(playerBullet,bulletTransform.position, Quaternion.identity);
        SFXmanager.instance.PlaySFX(_attackClip, this.transform, UnityEngine.Random.Range(1f, 1.5f));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
       rb.linearVelocity = dir * _bulletSpeed;
       bullet.transform.right = dir;

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0) _animator.SetTrigger("RangeRight");
            else _animator.SetTrigger("RangeLeft");
        }
        else
        {
            if (dir.y > 0) _animator.SetTrigger("RangeUp");
            else _animator.SetTrigger("RangeDown");
        }

    }
}
