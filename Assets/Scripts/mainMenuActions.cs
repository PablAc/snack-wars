using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuActions : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene("Snack Wars");
    }
    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
