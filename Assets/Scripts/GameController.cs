using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject PlayerObj;
    private PlayerHealt pHealth;
    [Header("UIElements")]
    [SerializeField] Slider healthSlider;
    float playerMaxHealth;
    float playerCurrentHealth;
    float showHealth;
    bool isHealthMoving;
    [SerializeField] GameObject victoryScreen;


    private void Awake()
    {
        if (instance == null) instance = this;
        pHealth = PlayerObj.GetComponent<PlayerHealt>();
        playerMaxHealth = pHealth.MaxHealth;
        playerCurrentHealth=pHealth.Health;
        isHealthMoving = false;
        healthSlider.maxValue = playerMaxHealth;
        healthSlider.value = playerCurrentHealth;
        showHealth = playerCurrentHealth;
    }
    private void Update()
    {
        playerCurrentHealth = pHealth.Health;
        healthSlider.value = showHealth;
        if (showHealth > playerCurrentHealth)
        {
            StartCoroutine (reduceHealthBar());
        }
        else if (showHealth < playerCurrentHealth)
        {
            StartCoroutine(aumentHealthBar());
        }
    }
    IEnumerator reduceHealthBar()
    {
        while (showHealth > playerCurrentHealth)
        {
            yield return 0.1f;
            showHealth -= 0.01f;
            if (showHealth - playerCurrentHealth <= 0.2f) showHealth = playerCurrentHealth;
        }
    }
    IEnumerator aumentHealthBar()
    {
        while (showHealth < playerCurrentHealth)
        {
            yield return 0.1f;
            showHealth += 0.1f;
            if (showHealth - playerCurrentHealth >= -0.2f) showHealth = playerCurrentHealth;
        }
    }
    public void ActivateVictoryScreen()
    {
        victoryScreen.SetActive(true);
        PlayerObj.SetActive(false);
    }
}
