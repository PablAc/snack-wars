using UnityEngine;

public class SectorControler : MonoBehaviour
{
    [SerializeField] private GameObject _bloquer;
    [SerializeField] private EnemyHP[] _enemies;

    private bool _sectorActivated;

    private void Start()
    {
        _bloquer.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!_sectorActivated && collision.CompareTag("Player"))
        {
            _sectorActivated = true;
            _bloquer.SetActive(true);
        }
    }

    private void Update()
    {
        if (_sectorActivated)
        {
            bool allDead = true;

            foreach (EnemyHP e in _enemies)
            {
                if (e != null)
                {
                    allDead = false;

                    break;
                }

            }
            if (allDead) 
            {
                _bloquer.SetActive(false);
                Destroy(gameObject);
            }

        }
    }

}
