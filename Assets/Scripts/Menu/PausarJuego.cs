using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PausarJuego : MonoBehaviour
{

    public GameObject menuPausa;
    public bool juegoPausado = false;


    private void OnPause(InputValue inputValue)
    {
        if (inputValue.Get<float>()>0f)
        {
            
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
 
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;
    }

    public void Pausar()
    {
      
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;
    }

    public void irAlMenu()
    {

        Time.timeScale = 1; 
        SceneManager.LoadScene("Menu");
    }
}