using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    public Transform Player;
    [SerializeField] private float _speed = 4f;



    void Start()
    {
       _rb2d=GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Player == null) return;

        Vector2 Target = new Vector2(Player.position.x, _rb2d.position.y);
        Vector2 NewPosition = Vector2.MoveTowards(_rb2d.position,Target, _speed*Time.fixedDeltaTime);

        _rb2d.MovePosition(NewPosition);
        
    }
}
