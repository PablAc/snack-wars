using System.Net.Sockets;
using UnityEngine;

public class BigDeco : MonoBehaviour
{
    [SerializeField] Transform physicalCenter;
    SpriteRenderer spriteRenderer;
    Transform playerPos;
    private void Awake()
    {
        playerPos = GameController.instance.PlayerObj.transform;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerPos.position.y > physicalCenter.position.y)
        {
            spriteRenderer.sortingLayerName = "FrontDeco";
        }else if(playerPos.position.y < physicalCenter.position.y)
        {
            spriteRenderer.sortingLayerName = "BackDeco";
        }
    }
}
