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
    float playerMaxAmmo;
    float playerCurrentAmmo;
    float showCurrentAmmo;
    [SerializeField] Slider ammoSlider;
    RangeAttack pRanged;
    


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
        pRanged = PlayerObj.GetComponent<RangeAttack>();
        playerMaxAmmo = pRanged.maxAmmo;
        playerCurrentAmmo = pRanged.currentAmmo;
        playerCurrentAmmo = playerMaxAmmo;
        ammoSlider.maxValue = playerMaxAmmo;
        ammoSlider.value = playerCurrentAmmo;
        showCurrentAmmo = playerCurrentAmmo;

    }
    private void Update()
    {
        playerCurrentHealth = pHealth.Health;
        healthSlider.value = showHealth;
        showCurrentAmmo = pRanged.currentAmmo;
        ammoSlider.value = showCurrentAmmo;
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
    IEnumerator reduceAmmoBar()
    {
        while (showCurrentAmmo > playerCurrentAmmo)
        {
            yield return 0.1f;
            showCurrentAmmo -= 0.01f;
            if (showCurrentAmmo - playerCurrentAmmo <= 0.2f) showCurrentAmmo = playerCurrentAmmo;
        }
    }
    IEnumerator aumentAmmoBar()
    {
        while (showCurrentAmmo < playerCurrentAmmo)
        {
            yield return 0.1f;
            showCurrentAmmo += 0.1f;
            if (showCurrentAmmo - playerCurrentAmmo >= -0.2f) showCurrentAmmo = playerCurrentAmmo;
        }
    }
    public void ActivateVictoryScreen()
    {
        victoryScreen.SetActive(true);
        PlayerObj.SetActive(false);
    }
}
