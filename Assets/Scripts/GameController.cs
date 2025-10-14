using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject PlayerObj;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
