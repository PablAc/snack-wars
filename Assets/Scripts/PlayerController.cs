using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float mvSpeed;
    Rigidbody2D myRb;
    Vector2 moveInput;
    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        myRb.linearVelocity = moveInput * mvSpeed;

    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

    }
}
