using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{


    public void Salir()
    {
        Application.Quit();
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("Nivel");
    }
}
