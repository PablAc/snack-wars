using UnityEngine;
using UnityEngine.InputSystem;

public class Textoinicio : MonoBehaviour
{

    [SerializeField] private GameObject _panel;

    private bool _isShowing = true;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (_isShowing && Keyboard.current.enterKey.wasPressedThisFrame) 
        {
            _panel.SetActive(false);
            Time.timeScale = 1f;
            _isShowing = false;

        }
    }

}
