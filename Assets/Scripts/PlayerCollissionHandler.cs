using UnityEngine;

public class PlayerCollissionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            //door code
            collision.GetComponent<DoorObj>().moveToNextRoom();
        }
    }
}
