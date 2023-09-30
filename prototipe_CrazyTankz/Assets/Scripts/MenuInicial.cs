using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
 
 public void CerrarJuego()
    {
            Application.Quit();
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LevelOption()
    {
        SceneManager.LoadScene(1);
    }
    public void CargarNvlOne()
    {
        SceneManager.LoadScene(2);
    }
    public void CargarNvlTwo()
    {
        SceneManager.LoadScene(3);
    }
    public void Gamewin()
    {
        SceneManager.LoadScene(3);
    }
    
}
