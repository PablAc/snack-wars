using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Rb2d;
    private Animator _animator;

    //Movimiento
    [SerializeField] private float  _speed;
    private Vector2  _moveInput;
    private Vector2  _lastMoveDir = Vector2.down;

    //Ataque Melee
    public GameObject _attackHitbox;
    [SerializeField] private float _attackDistance = 0.5f;
    [SerializeField] private float _attackCooldown = 0.4f;
    private float _lastAttackTime;

    


    private void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _attackHitbox.SetActive(false);
    }

    
    private void OnMove(InputValue inputValue)
    {
        _moveInput = inputValue.Get<Vector2>();
    }

    private void OnMelee(InputValue inputValue)
    {
        if (inputValue.Get<float>() > 0f)
            TryAttack();
    }

    private void Update()
    {
        _animator.SetFloat("MoveX", _moveInput.x);
        _animator.SetFloat("MoveY", _moveInput.y);
        
        
        
        
        if(_moveInput != Vector2.zero)
        {
            if (Mathf.Abs(_moveInput.x) > Mathf.Abs(_moveInput.y))
                _lastMoveDir = new Vector2(Mathf.Sign(_moveInput.x), 0f);
            else
                _lastMoveDir = new Vector2(0f, Mathf.Sign(_moveInput.y));

            _animator.SetFloat("LastMoveX", _moveInput.x);
        _animator.SetFloat("LastMoveY", _moveInput.y);
           
        }

        
    }

    private void FixedUpdate()
    {
        Rb2d.linearVelocity = _moveInput * _speed;

    }

   //Ataque Melee
    void TryAttack()
    {
        if (Time.time < _lastAttackTime + _attackCooldown) return;

        _lastAttackTime = Time.time;

        _attackHitbox.transform.localPosition = _lastMoveDir * _attackDistance;
        _attackHitbox.SetActive(true);

        if (Mathf.Abs(_lastMoveDir.x) > Mathf.Abs(_lastMoveDir.y))
        {
            if (_lastMoveDir.x > 0)
            {
                _animator.SetTrigger("AttackRight");
            }
            else
            {
                _animator.SetTrigger("AttackLefth");
            }


        }
        else
        {
            if (_lastMoveDir.y > 0)
            {
                _animator.SetTrigger("AttackUP");
            }
            else
            {
                _animator.SetTrigger("AttackDown");
            }


        }
    }

    public void EndAttack()
    {
        _attackHitbox.SetActive(false);
    }



    public Vector2 GetLastMoveDir()
    {
        return _lastMoveDir;
    }



}



