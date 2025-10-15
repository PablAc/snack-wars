using UnityEngine;

public class BlockDeactivateButton : MonoBehaviour
{
    [SerializeField] GameObject objToDeactivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objToDeactivate.SetActive(false);
        }
    }
}
