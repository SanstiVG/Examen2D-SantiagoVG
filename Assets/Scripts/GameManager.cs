using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int totalPuntos;
    private int puntos = 0;
    public TMP_Text textoPuntos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalPuntos = transform.childCount;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SumarPuntos()
    {
        puntos++;
        textoPuntos.text = puntos.ToString();
    }
}
