using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Rb2d;
    private Animator _animator;
    [SerializeField] private float _speed;
    private Vector2 _moveInput;
    private Vector2 _lastMoveDir = Vector2.down;


    private void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue inputValue)
    {
        _moveInput = inputValue.Get<Vector2>();
    }

    private void Update()
    {
        _animator.SetFloat("MoveX", _moveInput.x);
        _animator.SetFloat("MoveY", _moveInput.y);
        
        
        
        
        if(_moveInput.x != 0 || _moveInput.y != 0)
        {

        _animator.SetFloat("LastMoveX", _moveInput.x);
        _animator.SetFloat("LastMoveY", _moveInput.y);
           
        }

        
    }

    private void FixedUpdate()
    {
        Rb2d.linearVelocity = _moveInput * _speed;
    }

}
