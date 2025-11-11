using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    public Transform Player;
    public GameObject BossMeleeAttack;
    public Animator Animator;

    //Movimiento
    [SerializeField] private float _speed = 4f;

    //Ataque Melee
    [SerializeField]private float _attackDelay = 2f;
    private bool _isAttacking;
    [HideInInspector]public bool _playerInMeleeRange;


    void Start()
    {
       _rb2d=GetComponent<Rigidbody2D>();
        BossMeleeAttack.SetActive(false);
        Animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Player == null) return;

        Vector2 Target = new Vector2(Player.position.x, _rb2d.position.y);
        Vector2 NewPosition = Vector2.MoveTowards(_rb2d.position,Target, _speed*Time.fixedDeltaTime);

        _rb2d.MovePosition(NewPosition);
        
    }

    private void Update()
    {
        if (Player == null || _isAttacking) return;

        if (_playerInMeleeRange)
        {
            StartCoroutine(MeleeAttack());
        }
        else
        {
            StartCoroutine(RangedAttack());
        }

    }

    private System.Collections.IEnumerator MeleeAttack()
    {
        _isAttacking = (true);


        Animator.SetTrigger("MeleeAttack");
        yield return new WaitForSeconds(_attackDelay);
        _isAttacking = (false);

    }

    private System.Collections.IEnumerator RangedAttack()
    {
        _isAttacking= (true);
       

        Animator.SetTrigger("RangeAttack");
        yield return new WaitForSeconds(_attackDelay);
        _isAttacking = (false);

    }

    public void EnableColiderMelee()
    {
        BossMeleeAttack.SetActive(true);
    }
    public void DisableColiderMelee() 
    {
        BossMeleeAttack.SetActive(false);
    }

    

}
