using Unity.Cinemachine;
using UnityEngine;

public class DoorObj : MonoBehaviour
{
    [SerializeField] Transform centerPos;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject previousRoomConf;
    [SerializeField] GameObject nextroomConf;
    [SerializeField] CinemachineConfiner2D confinerComponent;

    public void moveToNextRoom()
    {
        previousRoomConf.SetActive(false);
        nextroomConf.SetActive(true);
        confinerComponent.BoundingShape2D = nextroomConf.GetComponent<Collider2D>();
        mainCamera.transform.position = centerPos.position;

    }
}
