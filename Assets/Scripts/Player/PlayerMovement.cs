using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Rb2d;
    [SerializeField] private float speed;


    private void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }


    private void OnMove(InputValue inputValue)
    {
        Vector2 move = inputValue.Get<Vector2>();
        Rb2d.linearVelocity = move * speed;
    }
}
