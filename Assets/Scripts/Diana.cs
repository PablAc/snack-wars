using UnityEngine;

public class Diana : MonoBehaviour
{
    [SerializeField] private GameObject _Puente;
    [SerializeField] private GameObject _Colicion;

    [SerializeField] private Sprite _spriteDesactivado;
    [SerializeField] private Sprite _spriteActivado;

    private SpriteRenderer _renderer;
    private bool _activated = false;

    private void Start()
    {
        _Puente.SetActive(false);
        
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = _spriteDesactivado;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("PlayerAttack")) 
        {
            _activated = true;
            _Puente.SetActive(true);
            _Colicion.SetActive(false);

            _renderer.sprite = _spriteActivado;

        }
    }
}
