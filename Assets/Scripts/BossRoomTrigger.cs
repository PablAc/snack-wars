using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{
    [SerializeField] GameObject BackWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MusicManager.instance.StopMusic();
            MusicManager.instance.PlayMusic(1,0.1f);
            BackWall.SetActive(true);
        }
    }
}
