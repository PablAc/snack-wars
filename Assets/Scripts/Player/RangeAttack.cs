using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangeAttack : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform bulletTransform;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _bulletCooldown = 0.4f;
    [SerializeField] private float _bulletCount = 5f;
    [SerializeField] private float _reloadTime = 3f;

    private PlayerMovement _playerMovement;
    private Animator _animator;
    private float _lastAttackTime;
    private float _bullets;
    private bool _isReloading;
    



    private void Start()
    {
        _playerMovement= GetComponent<PlayerMovement>();
        _animator= GetComponent<Animator>();
        _bullets = _bulletCount;
        
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
        if (_isReloading) return;
        if (_bullets <= 0)
        {
            StartCoroutine(Reload());
            return;
        }


        if (Time.time < _lastAttackTime + _bulletCooldown ) return;

        _lastAttackTime = Time.time;
        _bullets--;


        Vector2 dir = _playerMovement != null ?
                      _playerMovement.GetLastMoveDir() : Vector2.down;


       GameObject bullet = Instantiate(playerBullet,bulletTransform.position, Quaternion.identity);
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

        if (_bullets <= 0) 
        {
            StartCoroutine(Reload());
           
        }

    }

    private IEnumerator Reload()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_reloadTime);
        _bullets = _bulletCount;
        _isReloading = false;

    }

}
