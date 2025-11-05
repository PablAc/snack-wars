using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject PlayerObj;
    [Header("UIElements")]
    [SerializeField] Slider healthSlider;
    float playerMaxHealth;
    float playerCurrentHealth;
    float showHealth;


    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
