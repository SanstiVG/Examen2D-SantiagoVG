using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int totalPuntos;
    private int puntos = 0;
    private int vidas = 2;
    public TMP_Text textoPuntos;
    public TMP_Text textoVidas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalPuntos = transform.childCount;
        textoVidas.text = vidas.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
    }

    public void SumarPuntos()
    {
        puntos++;
        textoPuntos.text = puntos.ToString();
    }
    public void QuitarVida()
    {
        vidas--;
        textoVidas.text = vidas.ToString();


    }
    public void LlegarFinal()
    {
        SceneManager.LoadScene("Victoria");
    }
}
